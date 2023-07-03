using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int enemyCount;
    public float timeBetweenEnemies;
}

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public Wave[] waves = new Wave[3];

    private int currentWaveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waves[0] = new Wave();
        waves[0].enemyCount = 5;
        waves[0].timeBetweenEnemies = 1.5f;

        waves[1] = new Wave();
        waves[1].enemyCount = 8;
        waves[1].timeBetweenEnemies = 1.0f;

        waves[2] = new Wave();
        waves[2].enemyCount = 10;
        waves[2].timeBetweenEnemies = 0.8f;

        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(timeBetweenWaves);

        while (currentWaveIndex < waves.Length)
        {
            Wave currentWave = waves[currentWaveIndex];

            for (int i = 0; i < currentWave.enemyCount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(currentWave.timeBetweenEnemies);
            }

            currentWaveIndex++;
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
