using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float intervalBetweenSpawning = 3f;
    [SerializeField] int amountOfEnemies = 15;
    [SerializeField] Enemy enemyToSpawn = null;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        
    }
    IEnumerator SpawnEnemy()
    {
       for(int i = 0; i < amountOfEnemies; i++)
        {
            yield return new WaitForSeconds(intervalBetweenSpawning);

            Enemy enemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            enemy.transform.parent = this.transform;
        }
       

    }
   
}
