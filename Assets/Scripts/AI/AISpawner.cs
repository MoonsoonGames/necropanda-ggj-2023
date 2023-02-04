using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 1f;
    public Wave[] waves = new Wave[]
    {
        new Wave(5, 5f),
        new Wave(10, 7f),
        new Wave(15, 10f),
        new Wave (20, 15f),
        new Wave(25, 20f),
        new Wave(30, 25f),
        new Wave(37, 35f),
        new Wave (40, 45f),
        new Wave (50, 60f)
    };
    private int currentWave = 0;
    private float spawnTimer = 0f;

    private void Update()
    {
        if (currentWave >= waves.Length)
        {
            return;
        }

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= waves[currentWave].spawnTime)
        {
            for (int i = 0; i < waves[currentWave].enemyCount; i++)
            {
                Instantiate(enemyPrefab, transform.position, transform.rotation);
                spawnTimer = 0f;
            }
            currentWave++;
        }
    }
}

// Wave class, holds info about the wave
public class Wave
{
    public int enemyCount;
    public float spawnTime;

    public Wave(int enemyCount, float spawnTime)
    {
        this.enemyCount = enemyCount;
        this.spawnTime = spawnTime;
    }
}