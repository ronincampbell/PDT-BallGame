using System;
using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private MatchManagerChannel _matchManagerChannel;
    [SerializeField] private TextMeshProUGUI _preRoundText;
    
    private int _roundNumber = 1;

    private void Awake()
    {
        _matchManagerChannel.OnFinishRound += HandleRoundFinished;
        _matchManagerChannel.OnStartRound += HandleRoundStarted;
    }

    private void OnDestroy()
    {
        _matchManagerChannel.OnFinishRound -= HandleRoundFinished;
        _matchManagerChannel.OnStartRound -= HandleRoundStarted;
    }
    
    private void HandleRoundStarted()
    {
        _preRoundText.enabled = false;
    }

    private void HandleRoundFinished()
    {
        _preRoundText.enabled = true;
        _roundNumber++;
    }
}
