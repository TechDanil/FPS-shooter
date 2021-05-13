using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaveStatus
{
    Spawning,
    Waiting,
    Counting
}

public class EnemySpawnWaves : MonoBehaviour
{
    public Waves[] waves;
    [SerializeField] private WaveStatus waveStatus = WaveStatus.Counting;
    public Transform[] enemySpawnPoints;
    [SerializeField] private float timeBeetwenWaves =5f;
    [SerializeField] private float countDownWave;
    [SerializeField] private float searchCountDownWave;
    [SerializeField] private int numberEnemiesToSpawn;
    private int nextWave = 0;

    private void Start()
    {
        countDownWave = timeBeetwenWaves;
    }

    private void Update()
    {
        if(waveStatus == WaveStatus.Waiting)
        {
            if (!EnemyIsAlive())
            {
                CompeletedWave();
            }

            else
                return;
        }

        if (countDownWave <= 0f)
        {
            if (waveStatus != WaveStatus.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }

        else
        {
            countDownWave -= Time.deltaTime;
        }
    }

    private void CompeletedWave()
    {
        Debug.Log("Wave has completed");
        waveStatus = WaveStatus.Counting;
        countDownWave = timeBeetwenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All Waves Complete, LOOPING");
        }

        else
        {
            nextWave++;
        }
    }

    private bool EnemyIsAlive()
    {
        searchCountDownWave -= Time.deltaTime;
        if(searchCountDownWave <= 0f)
        {
            searchCountDownWave = 1f;

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator SpawnWave(Waves wave)
    {
        waveStatus = WaveStatus.Spawning;

        for(var i =0; i < wave.waveNumber; i++)
        {
            SpawnEnemies(wave.enemyPref);
            yield return new WaitForSeconds(1f / wave.enemyDelay);
        }

        waveStatus = WaveStatus.Waiting;
        yield break;
    }

    private void SpawnEnemies(GameObject enemy)
    {
        for(var i =0; i < numberEnemiesToSpawn; i++)
        {
            Transform spawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
    }
}

[System.Serializable]
public class Waves
{
    public string name;
    public float enemyDelay;
    public int waveNumber;
    public GameObject enemyPref;
}
