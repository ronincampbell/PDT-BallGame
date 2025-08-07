using System.Collections;
using UnityEngine;

public class EnemyTestingScript : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RunTestScripts());
    }


    IEnumerator RunTestScripts()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Attacking Player");
        enemySpawner.AttackPlayer();

        yield return new WaitForSeconds(1.0f);
        Debug.Log("Attacking Enemy");
        enemySpawner.GetCurrentEnemy().GetComponent<EnemyHealth>().TakeDamage(50.0f);

        yield return new WaitForSeconds(1.0f);
        Debug.Log("Attacking Enemy Again... They should be dead now");
        enemySpawner.GetCurrentEnemy().GetComponent<EnemyHealth>().TakeDamage(50.0f);

        yield return new WaitForSeconds(6.0f);
        Debug.Log("Checking if enemy is dead");
        if (enemySpawner.IsEnemyDead()) {
            Debug.Log("Enemy is dead, spawning a new one");
            enemySpawner.SpawnSpecificEnemy(1);
        }

        yield return new WaitForSeconds(1.0f);
        Debug.Log("Attacking Player");
        enemySpawner.AttackPlayer();
    }

}
