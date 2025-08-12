using UnityEngine;

public class PinballScore : MonoBehaviour
{
    private int score = 0;
    public GameObject floatingTextPrefab;
    private RectTransform uiCanvas;

    void Awake()
    {
        if (uiCanvas == null)
            uiCanvas = FindFirstObjectByType<Canvas>().GetComponent<RectTransform>();
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

        if (floatingTextPrefab != null && uiCanvas != null)
        {
            Vector3 hitPos = collision.contactCount > 0 ? collision.GetContact(0).point : collision.transform.position;
            Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, hitPos);
            GameObject floatingTextGO = Instantiate(floatingTextPrefab, uiCanvas);
            RectTransform floatingRect = floatingTextGO.GetComponent<RectTransform>();
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(uiCanvas, screenPoint, Camera.main, out localPoint);
            floatingRect.anchoredPosition = localPoint;
            FloatingText floatingText = floatingTextGO.GetComponent<FloatingText>();
            if (floatingText != null)
                floatingText.Setup("+" + points);
        }
    }
}
