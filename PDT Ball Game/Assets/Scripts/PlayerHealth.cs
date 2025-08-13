using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static readonly float maxHealth = 100;
    [SerializeField] private float currentHealth;
    public TMP_Text playerHealthText;
    [SerializeField] private RoundManager roundManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        if (!playerHealthText) { Debug.LogError("PlayerHealth: playerHealthText is missing, please assign in the inspector."); }
        UpdateHealthDisplay();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        UpdateHealthDisplay();

        if (HasDied()) {
            Debug.Log("Player died, restarting...");
            roundManager.Restart();
        }
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

    public void ResetMaxHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthDisplay();
    }

}
