using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn
    public Transform[] spawnPoints;   // Array of spawn locations (ensure you have 4)
    public float initialSpawnInterval = 5f;  // Initial spawn interval of 5 seconds

    private int enemiesToSpawn = 1;  // Start with 1 enemy to spawn
    private float elapsedTime = 0f;  // Track the elapsed time

    void Start()
    {
        // Start spawning enemies
        //StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true) // Run this loop indefinitely (until game ends)
        {
            yield return new WaitForSeconds(initialSpawnInterval);  // Wait for the specified interval

            // Spawn enemies based on the current wave size (enemiesToSpawn)
            SpawnWave(enemiesToSpawn);

            // Update elapsed time
            elapsedTime += initialSpawnInterval;

            // After 10 seconds, increase enemies to 2
            if (elapsedTime >= 10f && elapsedTime < 25f)
            {
                enemiesToSpawn = 2;
            }
            // After 25 seconds, increase enemies to 3
            else if (elapsedTime >= 25f && elapsedTime < 35f)
            {
                enemiesToSpawn = 3;
            }
            // After 35 seconds, spawn 4 enemies from all directions
            else if (elapsedTime >= 35f)
            {
                enemiesToSpawn = 4;
            }
        }
    }

    void SpawnWave(int enemyCount)
    {
        // Spawn 'enemyCount' enemies at random, different spawn points
        HashSet<int> usedSpawnPoints = new HashSet<int>(); // To ensure unique spawn points

        for (int i = 0; i < enemyCount; i++)
        {
            int spawnIndex;
            do
            {
                spawnIndex = Random.Range(0, spawnPoints.Length);
            } while (usedSpawnPoints.Contains(spawnIndex)); // Ensure we use a new spawn point

            usedSpawnPoints.Add(spawnIndex);
            SpawnEnemyAtPoint(spawnIndex);
        }
    }

    void SpawnEnemyAtPoint(int spawnIndex)
    {
        // Select a random enemy from the enemyPrefabs array
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        // Instantiate the enemy at the chosen spawn point
        Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}
