using UnityEngine;

public class PinballScore : MonoBehaviour
{
    private int score = 0;
    public GameObject floatingTextPrefab;
    private RectTransform uiCanvas;

    private PinballLauncher launcher;

    void Awake()
    {
        if (uiCanvas == null)
            uiCanvas = FindFirstObjectByType<Canvas>().GetComponent<RectTransform>();
    }

    void Start()
    {
        GameObject launcherObj = GameObject.FindGameObjectWithTag("Launcher");
        if (launcherObj != null)
            launcher = launcherObj.GetComponent<PinballLauncher>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int points = 0;

        switch (collision.collider.tag)
        {
            case "Bumper": points = 5; break;
            case "Spinner": points = 2; break;
            case "Slanted": points = 1; break;
            case "Paddle": points = 1; break;
            default: return;
        }

        score += points;
        Debug.Log($"Hit {collision.collider.tag}! Score: {score}");

        ShowFloatingText("+" + points, collision.GetContact(0).point, Color.white);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exit"))
        {
            ShowFloatingText("Total Damage: " + score, transform.position, Color.red);

            if (launcher != null)
                launcher.UnlockPinballLauncher(true);

            Destroy(gameObject);
        }
    }

    private void ShowFloatingText(string text, Vector3 worldPosition, Color color)
    {
        if (floatingTextPrefab != null && uiCanvas != null)
        {
            Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPosition);
            GameObject floatingTextGO = Instantiate(floatingTextPrefab, uiCanvas);
            RectTransform floatingRect = floatingTextGO.GetComponent<RectTransform>();

            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(uiCanvas, screenPoint, Camera.main, out localPoint);
            floatingRect.anchoredPosition = localPoint;

            FloatingText floatingText = floatingTextGO.GetComponent<FloatingText>();
            if (floatingText != null)
                floatingText.Setup(text);
        }
    }
}
