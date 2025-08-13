using System.Collections;
using UnityEngine;

public class MageAttack : EnemyAttack
{
    [SerializeField] private MatchManagerChannel _matchManagerChannel;

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

        // 50% chance to trigger the special gravity attack
        bool triggerGravityAttack = Random.value < 0.5f; // Random.value gives a float between 0 and 1

        if (triggerGravityAttack)
        {
            // Spawn gravity effect manager for next round
            var go = new GameObject("GravityEffectManager");
            var effectManager = go.AddComponent<GravityEffectManager>();
            effectManager.Init(_matchManagerChannel);

            // Delay applying gravity until round start
            _matchManagerChannel.OnStartRound += () =>
            {
                if (effectManager != null) { effectManager.ApplyGravityEffect(); }
            };

            Debug.Log($"Mage attacked player with {attackDamage} — Gravity attack queued for next round start.");
        }
        else
        {
            Debug.Log($"Mage attacked player with {attackDamage} — No gravity attack this time.");
        }
    }
}
