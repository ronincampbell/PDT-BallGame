using NUnit.Framework;
using UnityEngine;

public class ThiefAttack : EnemyAttack
{
    protected override void Start()
    {
        base.Start();
    }

    public override void AtttackPlayer()
    {
        if (playerHealth == null)
        {
            Debug.Log("ThiefAttack: could not find playerHealth Component. Make sure the player has the 'Player' tag.");
            return;
        }

        playerHealth.TakeDamage(attackDamage);

        // 50% chance to destroy a random mechanic
        if (Random.value < 0.5f)
        {
            GameObject parent = GameObject.FindGameObjectWithTag("MachineMechanicsList");
            if (parent != null && parent.transform.childCount > 0)
            {
                // Pick a random child
                int randomIndex = Random.Range(0, parent.transform.childCount);
                Transform child = parent.transform.GetChild(randomIndex);

                // Destroy it
                GameObject.Destroy(child.gameObject);
                Debug.Log($"Thief attacked player with {attackDamage} — Random mechanic '{child.name}' destroyed.");
            }
            else
            {
                Debug.Log("Thief attack: No mechanics found to destroy.");
            }
        }
        else
        {
            Debug.Log($"Thief attacked player with {attackDamage} — No mechanic destroyed this time.");
        }
    }

}
