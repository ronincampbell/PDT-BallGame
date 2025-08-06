using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static readonly float maxHealth = 100;
    [SerializeField] private float currentHealth;
    public TMP_Text enemyHealthUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public bool HasDied()
    {
        return currentHealth <= 0;
    }

}
