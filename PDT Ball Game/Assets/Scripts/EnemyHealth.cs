using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static readonly float maxHealth = 100;
    [SerializeField] private float currentHealth;
    private TMP_Text enemyHealthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthDisplay();
    }

    public void Initalise(TMP_Text text)
    {
        enemyHealthText = text;
        UpdateHealthDisplay();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        if (enemyHealthText != null)
        {
            enemyHealthText.text = "Enemy Health: " + currentHealth;
        }
    }

    public bool HasDied()
    {
        return currentHealth <= 0;
    }

}
