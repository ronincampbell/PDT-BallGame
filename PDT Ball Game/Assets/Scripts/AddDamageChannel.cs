using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AddDamageChannel", menuName = "Scriptable Objects/AddDamageChannel")]
public class AddDamageChannel : ScriptableObject
{
    public Action<int> OnAddDamage;
    
    public void AddDamage(int amount)
    {
        OnAddDamage?.Invoke(amount);
    }
}
