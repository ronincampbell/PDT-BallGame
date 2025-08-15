using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private AddCoinsChannel _addCoinsChannel;
    [SerializeField] private AddPointsChannel _addPointsChannel;
    [SerializeField] private AddDamageChannel _addDamageChannel;
    [SerializeField] private MatchManagerChannel _matchManagerChannel;
    [SerializeField] private List<BuyMechanismButton> _mechanisms;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private float _currentMoney = 30;
    [SerializeField] private float _currentPoints = 0;
    [SerializeField] private float _currentDamage = 0;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject mechanicsParent;

    private void Awake()
    {
        _addCoinsChannel.OnAddCoins += AddCoins;
        _addPointsChannel.OnAddPoints += AddPoints;
        _addDamageChannel.OnSetRoundDamage += SetRoundDamage;
        _matchManagerChannel.OnFinishRound += UpdateLocks;
        _matchManagerChannel.OnStartRound += ForceLockAllItems;
        Initialize();
    }

    private void OnDestroy()
    {
        _addCoinsChannel.OnAddCoins -= AddCoins;
        _addPointsChannel.OnAddPoints -= AddPoints;
        _addDamageChannel.OnSetRoundDamage -= SetRoundDamage;
        _matchManagerChannel.OnFinishRound -= UpdateLocks;
        _matchManagerChannel.OnStartRound -= ForceLockAllItems;
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

    private void BuyItemHandler(float price, GameObject item, RectTransform spawn2)
    {
        if (price <= _currentMoney)
        {
            AddCoins(price * -1);
            RectTransform spawn = _canvas.GetComponent<RectTransform>();
            PlaceableMechanismComponent placeableMechanismComponent = Instantiate(item, spawn).GetComponent<PlaceableMechanismComponent>();
            placeableMechanismComponent.transform.SetParent(mechanicsParent.transform);
            placeableMechanismComponent.Setup(spawn, price);
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

    private void ForceLockAllItems()
    {
        foreach (BuyMechanismButton mechanism in _mechanisms)
        {
            mechanism.EnableLock(false);
        }
        
        
    }
    
    private void AddCoins(float amount)
    {
        _currentMoney += amount;
        _moneyText.text = _currentMoney.ToString();
    }
    
    private void SetRoundDamage(int damage)
    {
        _currentDamage = damage;
        _damageText.text = _currentDamage.ToString();
    }

    private void AddPoints(int points)
    {
        _currentPoints += points;
        _scoreText.text = _currentPoints.ToString();
    }
}
