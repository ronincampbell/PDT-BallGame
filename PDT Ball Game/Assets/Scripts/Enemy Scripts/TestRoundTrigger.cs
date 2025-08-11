using UnityEngine;
using UnityEngine.InputSystem;

public class TestRoundTrigger : MonoBehaviour
{
    [SerializeField] private MatchManagerChannel _matchManagerChannel;

    private Keyboard keyboard;

    private void Awake()
    {
        keyboard = Keyboard.current;
    }

    private void Update()
    {
        if (keyboard.sKey.wasPressedThisFrame)
        {
            Debug.Log("=== TEST: Starting round ===");
            _matchManagerChannel.StartRound();
        }

        if (keyboard.fKey.wasPressedThisFrame)
        {
            Debug.Log("=== TEST: Finishing round ===");
            _matchManagerChannel.FinishRound();
        }
    }
}
