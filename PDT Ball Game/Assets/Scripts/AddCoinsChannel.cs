using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AddCoinsChannel", menuName = "Scriptable Objects/AddCoinsChannel")]
public class AddCoinsChannel : ScriptableObject
{
    public Action<float> OnAddCoins;
    
    public void AddCoins(float amount)
    {
        OnAddCoins?.Invoke(amount);
    }
}
