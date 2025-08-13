using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private MatchManagerChannel _matchManagerChannel;
    [SerializeField] private TextMeshProUGUI _preRoundText;
    [SerializeField] private EnemySpawner enemySpawner;
    
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
        StartCoroutine(DelayEndOfRoundLogic());
    }

    private IEnumerator DelayEndOfRoundLogic()
    {
        yield return new WaitForSeconds(0.5f);
        enemySpawner.EndOfRoundLogic();
    }

    public void Restart()
    {
        // Show text then restart
        _preRoundText.text = "GAME OVER!";
        Invoke("RestartGame", 5.0f);
    }

    private void RestartGame()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

}
