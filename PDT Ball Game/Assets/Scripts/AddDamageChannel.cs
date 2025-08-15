using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AddDamageChannel", menuName = "Scriptable Objects/AddDamageChannel")]
public class AddDamageChannel : ScriptableObject
{
    public Action<int> OnSetRoundDamage;
    
    public void SetRoundDamage(int amount)
    {
        OnSetRoundDamage?.Invoke(amount);
    }
}
