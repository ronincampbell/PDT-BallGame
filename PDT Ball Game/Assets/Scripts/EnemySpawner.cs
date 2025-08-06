using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyPrefabs;
    public Vector3 enemySpawnPositon = new Vector3(0,-20f,0);
    [SerializeField] private TMP_Text healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
        if (!healthText) { Debug.LogError("EnemySpawner: healthText is missing, please assign in the inspector."); }
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(EnemyPrefabs[0]);
        enemy.transform.SetPositionAndRotation(enemySpawnPositon, transform.rotation);
        enemy.GetComponent<EnemyHealth>().Initalise(healthText);
    }

    public void SpawnRandomEnemy()
    {
        GameObject enemy = Instantiate(EnemyPrefabs[ChooseRandomEnemy()]);
        enemy.transform.SetPositionAndRotation(enemySpawnPositon, transform.rotation);
        enemy.GetComponent<EnemyHealth>().Initalise(healthText);
    }

    private int ChooseRandomEnemy()
    {
        int random = Random.Range(0, EnemyPrefabs.Count);
        return random;
    }

}
