using System.Collections;
using UnityEngine;

public class GravityEffectManager : MonoBehaviour
{
    private MatchManagerChannel _matchManagerChannel;

    public void Init(MatchManagerChannel matchManagerChannel)
    {
        _matchManagerChannel = matchManagerChannel;
        _matchManagerChannel.OnFinishRound += StopGravityEffect;
    }

    private void OnDestroy()
    {
        if (_matchManagerChannel != null)
            _matchManagerChannel.OnFinishRound -= StopGravityEffect;
    }

    public void ApplyGravityEffect()
    {
        StartCoroutine(ApplyGravityAfterDelay(1f));
    }

    private IEnumerator ApplyGravityAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Physics2D.gravity = new Vector3(0, -9.81f * 2.2f, 0);
        Debug.Log("GravityEffectManager: Strong gravity applied after delay.");
    }

    private void StopGravityEffect()
    {
        Physics2D.gravity = new Vector3(0, -9.81f, 0);
        Debug.Log("GravityEffectManager: Gravity reset at round end.");
        Destroy(gameObject);
    }
}

