using System.Collections.Generic;
using UnityEngine;

public class PinballLauncher : MonoBehaviour
{
    [SerializeField] private GameObject pinball;
    [SerializeField] private int pinballCount;
    [SerializeField] private float launchForce = 500f;

    private int ballsRemaining;
    private bool canLaunch = true;

    public KeyCode activationKey = KeyCode.L;

    void Start()
    {
        ballsRemaining = pinballCount;
    }

    void Update()
    {
        if (Input.GetKeyDown(activationKey) && canLaunch && ballsRemaining > 0)
        {
            LaunchPinball();
            UnlockPinballLauncher(false);
        }
    }

    void LaunchPinball()
    {
        GameObject ball = Instantiate(pinball, transform.position, Quaternion.identity);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.up * launchForce);
        }

        ballsRemaining--;
    }

    public void UnlockPinballLauncher(bool canUnlock)
    {
        canLaunch = canUnlock;
    }
}
