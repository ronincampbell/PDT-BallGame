using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AddPointsChannel", menuName = "Scriptable Objects/AddPointsChannel")]
public class AddPointsChannel : ScriptableObject
{
    public Action<int> OnAddPoints;
    
    public void AddPoints(int amount)
    {
        OnAddPoints?.Invoke(amount);
    }
}
