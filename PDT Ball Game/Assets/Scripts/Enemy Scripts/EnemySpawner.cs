using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyPrefabs;
    public Vector3 enemySpawnPositon;
    private EnemyAttack currentEnemy;
    [SerializeField] private TMP_Text healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnSpecificEnemy(0);
        if (!healthText) { Debug.LogError("EnemySpawner: healthText is missing, please assign in the inspector."); }
    }

    public void SpawnRandomEnemy()
    {
        GameObject enemy = Instantiate(EnemyPrefabs[ChooseRandomEnemy()]);
        enemy.transform.SetPositionAndRotation(enemySpawnPositon, transform.rotation);
        enemy.GetComponent<EnemyHealth>().Initalise(healthText);
        currentEnemy = enemy.GetComponent<EnemyAttack>();
    }

    public void SpawnSpecificEnemy(int enemyIndex)
    {
        if (enemyIndex >= EnemyPrefabs.Count || enemyIndex < 0) { Debug.Log("SpawnSpecificEnemy(): invalid enemyIndex"); return; }

        GameObject enemy = Instantiate(EnemyPrefabs[enemyIndex]);
        enemy.transform.SetPositionAndRotation(enemySpawnPositon, transform.rotation);
        enemy.GetComponent<EnemyHealth>().Initalise(healthText);
        currentEnemy = enemy.GetComponent<EnemyAttack>();
    }

    private int ChooseRandomEnemy()
    {
        int random = Random.Range(0, EnemyPrefabs.Count);
        return random;
    }

    public bool IsEnemyDead()
    {
        if (!currentEnemy) { return true; } else { return false; }
    }
    public EnemyAttack GetCurrentEnemy() { return currentEnemy; }
    public void AttackPlayer() { GetCurrentEnemy().AtttackPlayer(); }

    public void EndOfRoundLogic()
    {
        //Debug.Log("End of Round Logic");
        if (IsEnemyDead())
        {
            Debug.Log("Enemy is dead at end of round");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().ResetMaxHealth();
            SpawnRandomEnemy();
        } else
        {
            Debug.Log("Enemy is alive and attacks player");
            AttackPlayer();
        }
    }
}
