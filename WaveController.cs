using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour
{
    private Manager manager;

    public bool spawning = true;
    public int waveNumber = 1;

    private WaveObject currentWave;
    public WaveObject[] wavesArray = new WaveObject[1];
    [SerializeField]
    private GameObject[] enemies;

    public Transform[] spawnPoints = new Transform[3];

    private void Awake()
    {
        manager = gameObject.GetComponent<Manager>();
        StartCoroutine(WaveStart(waveNumber));
    }

    private void Update()
    {
        //If there are no more enemies, then next wave
        if (manager.activeEnemies.Length <= 0)
        {
            waveNumber++;
            NextWave();
        }
    }

    IEnumerator WaveStart(int _waveIndex)
    {
        //Can be a future fault, if next wave doesn't start
        currentWave = wavesArray[_waveIndex - 1];

        ApplyEnemiesToArray();

        WaitForSeconds wait = new WaitForSeconds(currentWave.secondsBetweenSpawns);
        for (int j = 0; j < enemies.Length; j++)
        {
            yield return wait;
            spawning = true;
            Instantiate(enemies[j], SpawnPointPicker().position, SpawnPointPicker().rotation);
            Debug.Log("SPAWNED");
        }
    }

    private void NextWave()
    {
        StartCoroutine(WaveStart(waveNumber));
    }

    private void ApplyEnemiesToArray()
    {
        int enemiesToSpawn;

        enemiesToSpawn = currentWave.basicEnemiesToSpawn /*+ Other enemies*/;
        enemies = new GameObject[enemiesToSpawn];

        //Basic Enemies
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            enemies[i] = currentWave.basicEnemy;
        }
    }

    private Transform SpawnPointPicker()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
}
