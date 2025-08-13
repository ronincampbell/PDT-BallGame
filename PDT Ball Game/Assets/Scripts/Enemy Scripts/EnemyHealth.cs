using System.Collections;
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

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthDisplay();
        if (HasDied()) {
            Debug.Log("Enemy has died.");
            Destroy(gameObject);
        }
    }

    private void UpdateHealthDisplay()
    {
        if (enemyHealthText != null)
        {
            enemyHealthText.text = "Enemy Health: " + currentHealth;
        }
    }

    public bool HasDied() { return currentHealth <= 0; }

    IEnumerator Die()
    {
        // TO-DO: Play Death animation here
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }

}
