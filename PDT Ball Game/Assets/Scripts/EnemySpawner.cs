using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyPrefabs;
    public Vector3 enemySpawnPositon = new Vector3(0,-20f,0);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(EnemyPrefabs[0]);
        enemy.transform.SetPositionAndRotation(enemySpawnPositon, transform.rotation);
    }

    public void SpawnRandomEnemy()
    {
        GameObject enemy = Instantiate(EnemyPrefabs[ChooseRandomEnemy()]);
        enemy.transform.SetPositionAndRotation(enemySpawnPositon, transform.rotation);
    }

    private int ChooseRandomEnemy()
    {
        int random = Random.Range(0, EnemyPrefabs.Count);
        return random;
    }

}
