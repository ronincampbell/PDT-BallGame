using UnityEngine;

[CreateAssetMenu(fileName = "PurchasableMechanism", menuName = "Scriptable Objects/PurchasableMechanism")]
public class PurchasableMechanism : ScriptableObject
{
    [SerializeField] private GameObject _mechanism;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _price;
    
    public GameObject Mechanism => _mechanism;
    public Sprite Sprite => _sprite;
    public float Price => _price;
}
