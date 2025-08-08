using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private AddCoinsChannel _addCoinsChannel;
    [SerializeField] private AddPointsChannel _addPointsChannel;
    [SerializeField] private AddDamageChannel _addDamageChannel;
    [SerializeField] private List<BuyMechanismButton> _mechanisms;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private float _currentMoney = 300;
    [SerializeField] private float _currentPoints = 0;
    [SerializeField] private float _currentDamage = 0;

    private void Awake()
    {
        _addCoinsChannel.OnAddCoins += AddCoins;
        _addPointsChannel.OnAddPoints += AddPoints;
        _addDamageChannel.OnAddDamage += AddDamage;
        Initialize();
    }

    private void OnDestroy()
    {
        _addCoinsChannel.OnAddCoins -= AddCoins;
        _addPointsChannel.OnAddPoints -= AddPoints;
        _addDamageChannel.OnAddDamage -= AddDamage;
    }
    
    private void Initialize()
    {
        _moneyText.text = _currentMoney.ToString();
        _damageText.text = _currentDamage.ToString();
        _scoreText.text = _currentPoints.ToString();

        foreach (BuyMechanismButton mechanism in _mechanisms)
        {
            mechanism.OnBuy += BuyItemHandler;
        }
        
        UpdateLocks();
    }

    private void BuyItemHandler(float price, GameObject item)
    {
        if (price <= _currentMoney)
        {
            AddCoins(price * -1);
            Instantiate(item);
        }

        UpdateLocks();
    }

    private void UpdateLocks()
    {
        foreach (BuyMechanismButton mechanism in _mechanisms)
        {
            bool playerCanBuy = mechanism.Price <= _currentMoney;
            mechanism.EnableLock(!playerCanBuy);
        }
    }
    
    private void AddCoins(float amount)
    {
        _currentMoney += amount;
        _moneyText.text = _currentMoney.ToString();
    }
    
    private void AddDamage(int damage)
    {
        _currentDamage += damage;
        _damageText.text = _currentDamage.ToString();
    }

    private void AddPoints(int points)
    {
        _currentPoints += points;
        _scoreText.text = _currentPoints.ToString();
    }
}
