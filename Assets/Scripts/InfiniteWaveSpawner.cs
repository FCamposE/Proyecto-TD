using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteWaveSpawner : MonoBehaviour
{
    /*public GameObject enemyPrefab;
    public float timeBetweenWaves = 20f;
    public float difficultyIncreaseInterval = 20f;

    private int currentWave = 0;
    private float nextWaveTime;
    private float nextDifficultyIncreaseTime;
    private int numEnemiesPerWave = 4;
    private float timeBetweenEnemies = 5f;*/

    public GameObject enemyPrefab;
    public int enemiesPerWave = 10;
    public float timeBetweenEnemies = 1f;
    public float timeBetweenWaves = 5f;


    /*private float enemySpeedIncrease = 0.5f;
    private int enemyHealthIncrease = 5;*/


    private int currentWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        //StartNextWave();
        StartCoroutine(StartWave());
        //nextDifficultyIncreaseTime = Time.time + difficultyIncreaseInterval;
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log(Time.time);
        if (Time.time >= nextWaveTime)
        {
            StartNextWave();
        }

        if (Time.time >= nextDifficultyIncreaseTime)
        {
            IncreaseDifficulty();
            nextDifficultyIncreaseTime = Time.time + difficultyIncreaseInterval;
        }*/
    }
    public int getCurrentWave(){
        return currentWave;
    }
    private IEnumerator StartWave()
    {
        while (true)
        {
            currentWave++;
            //Debug.Log("Starting Wave " + currentWave);

            for (int i = 0; i < enemiesPerWave; i++)
            {
                Instantiate(enemyPrefab, transform.position, transform.rotation);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
            enemiesPerWave += 1;
            //IncreaseDifficulty();
        }
    }
    /*private void StartNextWave()
    {
        currentWave++;
        Debug.Log("Starting Wave " + currentWave);

        StartCoroutine(SpawnEnemiesInWave(numEnemiesPerWave, timeBetweenEnemies));

        // Generar enemigos de la oleada actual
        // Configurar los atributos del enemigo según la oleada actual
        // ...

        nextWaveTime = Time.time + timeBetweenWaves;
    }
    private IEnumerator SpawnEnemiesInWave(int numEnemies, float delay)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);

            // Configurar los atributos del enemigo según la oleada actual
            // ...

            yield return new WaitForSeconds(delay);
        }
    }*/
    private void IncreaseDifficulty()
    {
        Debug.Log("Increasing Difficulty");

        // Aumentar la velocidad de los enemigos existentes
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            //enemy.speed += enemySpeedIncrease;
            //enemy.initialHealth += enemyHealthIncrease;
            //enemy.IncreaseStats(enemySpeedIncrease,enemyHealthIncrease);
        }
    }
}
