using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MatchManagerChannel", menuName = "Scriptable Objects/MatchManagerChannel")]
public class MatchManagerChannel : ScriptableObject
{
    public Action OnStartRound;
    public Action OnFinishRound;

    public void StartRound()
    {
        OnStartRound?.Invoke();
    }

    public void FinishRound()
    {
        OnFinishRound?.Invoke();
    }
}
