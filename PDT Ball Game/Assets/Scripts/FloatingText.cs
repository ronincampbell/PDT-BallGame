using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float fadeDuration = 1f;

    private TMP_Text tmp;
    private Color originalColor;
    private RectTransform rectTransform;
    private float timer;

    void Awake()
    {
        tmp = GetComponent<TMP_Text>();
        if (tmp != null)
            originalColor = tmp.color;
        else
            Debug.LogError("FloatingText: No TMP_Text component found!");

        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
            Debug.LogError("FloatingText: No RectTransform component found!");
    }

    public void Setup(string text)
    {
        tmp.text = text;
        timer = 0f;
    }

    void Update()
    {
        if (tmp == null || rectTransform == null)
            return;

        timer += Time.deltaTime;
        float alpha = Mathf.Lerp(originalColor.a, 0, timer / fadeDuration);
        tmp.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

        if (timer >= fadeDuration)
            Destroy(gameObject);
    }
}
