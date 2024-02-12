using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public float spawnRate = 2f;
    public float spawnRateIncrease = 0.1f;
    public float timeToIncreaseSpawnRate = 10f;
    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnRate;
        InvokeRepeating(nameof(IncreaseSpawnRate), timeToIncreaseSpawnRate, timeToIncreaseSpawnRate);
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[randomIndex], spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);
    }

    void IncreaseSpawnRate()
    {
        spawnRate -= spawnRateIncrease;
        spawnRate = Mathf.Clamp(spawnRate, 0.1f, float.MaxValue);
    }
}
