using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BuyMechanismButton : MonoBehaviour
{
    public Action<float, GameObject, RectTransform> OnBuy;
    
    [SerializeField] private PurchasableMechanism _mechanism;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private Image _splashImage;
    [SerializeField] private Image _lockPanel;

    public float Price => _mechanism.Price;
    
    public void EnableLock(bool enabled)
    {
        _lockPanel.gameObject.SetActive(enabled);
    }    
    
    private void Start()
    {
        _priceText.text = "$" + _mechanism.Price;
        _splashImage.sprite = _mechanism.Sprite;
        
        _button.onClick.AddListener(HandlePurchase);
    }

    private void HandlePurchase()
    {
        OnBuy?.Invoke(_mechanism.Price, _mechanism.Mechanism, _splashImage.rectTransform);
    }
}
