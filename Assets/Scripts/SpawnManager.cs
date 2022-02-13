using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float xposition;
    private float zposition;
    public GameObject[] powerupprefab;
    public GameObject enemyPrefab;
    private int enemycount;
    private int waveNumber = 1;
    private int spawnRange = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PowerUpSpawn", 2, 10);
        SpawnEnemyWave(waveNumber);
    }

    void Update()
    {
        enemycount = GameObject.FindObjectsOfType<EnemyController>().Length;
        if (enemycount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
    //Spawning Power up
    void PowerUpSpawn()
    {
        xposition = Random.Range(-spawnRange, spawnRange);
        zposition = Random.Range(-spawnRange, spawnRange);
        int index = Random.Range(0, powerupprefab.Length);
        Vector3 position = new Vector3(xposition, transform.position.y, zposition);
        Instantiate(powerupprefab[index], position, powerupprefab[index].transform.rotation);
    }
    //Place Enemies at certain position
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    //Spawn Enemies
    void SpawnEnemyWave(int enemiestospawn)
    {
        for (int i = 0; i < enemiestospawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

    }
}


