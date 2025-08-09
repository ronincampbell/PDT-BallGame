using System.Collections;
using UnityEngine;

public class MageAttack : EnemyAttack
{
    protected override void Start()
    {
        base.Start();
    }

    public override void AtttackPlayer()
    {
        if (playerHealth == null)
        {
            Debug.Log("MageAttack: could not find playerHealth Component. Make sure the player has the 'Player' tag.");
            return;
        }

        playerHealth.TakeDamage(attackDamage);
        StartCoroutine(GravityAttack());
        // TO-DO: Gravity increase attack in next round
        Debug.Log($"Mage attacked player with {attackDamage}");
    }

    IEnumerator GravityAttack()
    {
        ApplyStrongerGravity();
        yield return new WaitForSeconds(60.0f);
        ResetGravity();
    }

    private void ApplyStrongerGravity()
    {
        Physics.gravity = new Vector3(0, -9.81f*2f, 0);
        Debug.Log("MageAttack: Applying Strong gravity");
    }

    private void ResetGravity()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        Debug.Log("MageAttack: Resetting gravity back to normal");
    }
}
