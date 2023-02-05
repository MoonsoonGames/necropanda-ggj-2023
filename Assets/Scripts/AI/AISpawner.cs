using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AISpawner : MonoBehaviour
{
    public static AISpawner instance;

    private void Start()
    {
        instance = this;

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "GameScene")
        {
            Invoke("SpawnNextWave", 15);
        }
    }

    public GameObject enemyPrefab;
    public float spawnDelay = 1f;
    public Wave[] waves = new Wave[]
    {
        new Wave(5),
        new Wave(10),
        new Wave(15),
        new Wave (20),
        new Wave(25),
        new Wave(30),
        new Wave(37),
        new Wave (40),
        new Wave (50)
    };
    private int currentWave = 0;

    public void EnemyKilled()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        if (enemies.Length <= 0)
        {
            //open up shop menu
        }
    }

    public void ShopClosed()
    {
        Invoke("SpawnNextWave", 15);
    }

    [ContextMenu("Spawn next wave")]
    public void SpawnNextWave()
    {
        if (currentWave >= waves.Length)
        {
            WinGame();
            return;
        }

        for (int i = 0; i < waves[currentWave].enemyCount; i++)
        {
            Invoke("SpawnEnemy", i * spawnDelay);
        }

        currentWave++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

    void WinGame()
    {
        //disconnect omline thingy
        //return to main scfrn
    }
}

// Wave class, holds info about the wave
[System.Serializable]
public class Wave
{
    public int enemyCount;

    public Wave(int enemyCount)
    {
        this.enemyCount = enemyCount;
    }
}