using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    protected PlayerHealth playerHealth;
    public float attackDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        if (playerHealth == null) {
            Debug.Log("EnemyAttack Start(): could not find playerHealth Component. Make sure the player has the 'Player' tag.");
        }
        if (attackDamage == 0) { Debug.Log("Enemy attackDamage is set to 0, make sure you set the damage on the PreFab."); }
    }

    public abstract void AtttackPlayer();

}
