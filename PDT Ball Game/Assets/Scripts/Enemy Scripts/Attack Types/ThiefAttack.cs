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
        // TO-DO: Remove random bumper in machine (need reference to list of placed bumpers)
        Debug.Log($"Thief attacked player with {attackDamage}");
    }

}
