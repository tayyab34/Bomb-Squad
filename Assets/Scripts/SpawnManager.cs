using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float xposition;
    private float zposition;
    public GameObject[] powerupprefab;
    public GameObject enemyPrefab;
    private float spawnRange = 10;
    public int enemycount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PowerUpSpawn", 2, 10);
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemycount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
    void PowerUpSpawn()
    {
        xposition = Random.Range(-10, 10);
        zposition = Random.Range(-10, 10);
        int index = Random.Range(0, powerupprefab.Length);
        Vector3 position = new Vector3(xposition, transform.position.y, zposition);
        Instantiate(powerupprefab[index], position, powerupprefab[index].transform.rotation);
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    void SpawnEnemyWave(int enemiestospawn)
    {
        for (int i = 0; i < enemiestospawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

    }
}


