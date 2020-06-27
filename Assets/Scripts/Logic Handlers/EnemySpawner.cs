using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemySpawner : MonoBehaviour
{
    
    [Range(0.1f,10f)][SerializeField] float intervalBetweenSpawning = 3f;
    [SerializeField] int amountOfEnemies = 15;
    [SerializeField] Enemy enemyToSpawn = null;
    [SerializeField] AudioClip spawnSound;

    [SerializeField] int scoreIncreaseAmount = 10;

    ScoreHandler scoreText;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText = FindObjectOfType<ScoreHandler>();
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
       for(int i = 0; i < amountOfEnemies; i++)
        {
            ProccesEnemySpawning();

            yield return new WaitForSeconds(intervalBetweenSpawning);
        }


    }

    private void ProccesEnemySpawning()
    {
        Enemy enemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(spawnSound);
        enemy.transform.parent = this.transform;
        scoreText.IncreaseScore(scoreIncreaseAmount);
    }
}
