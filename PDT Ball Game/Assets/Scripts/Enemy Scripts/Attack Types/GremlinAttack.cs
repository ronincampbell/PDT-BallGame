using UnityEngine;

public class GremlinAttack : EnemyAttack
{
    protected override void Start()
    {
        base.Start();
    }

    public override void AtttackPlayer()
    {
        if (playerHealth == null)
        {
            Debug.Log("GremlinAttack: could not find playerHealth Component. Make sure the player has the 'Player' tag.");
            return;
        }

        playerHealth.TakeDamage(attackDamage);
        Debug.Log($"Gremlin attacked player with {attackDamage}");
    }

}
