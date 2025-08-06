using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static readonly float maxHealth = 100;
    [SerializeField] private float currentHealth;
    public TMP_Text playerHealthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        if (!playerHealthText) { Debug.LogError("PlayerHealth: playerHealthText is missing, please assign in the inspector."); }
        UpdateHealthDisplay();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        if (playerHealthText != null)
        {
            playerHealthText.text = "Player Health: " + currentHealth;
        }
    }

    public bool HasDied()
    {
        return currentHealth <= 0;
    }

}
