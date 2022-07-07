using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemy;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public static int waveNo = 1;

    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        if (Bullet.waveSize <= 0)
        { 
            countdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave()
    {
        Bullet.waveSize = waveNo;

        waveNo++;
        for (int i = 0; i < waveNo - 1; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
