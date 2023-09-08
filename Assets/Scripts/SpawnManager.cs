using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    private int waveCount;
    private int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        waveCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveCount);
            waveCount++;
        }
    }

    private Vector3 PickRandomSpawn()
    {
        int diceRoll = Random.Range (1, 10);
        float spawnPosX = Random.Range(20, 35);
        
        if (diceRoll <6)
        {
            spawnPosX *= -1;
        }

        Vector3 randomSpawn = new Vector3(spawnPosX, 0, -4);

        return randomSpawn;
    }

    void SpawnEnemyWave(int spawnCredits)
    {
        for (int i = 0; i < spawnCredits; i++)
        {
            Instantiate(enemy, PickRandomSpawn(), enemy.transform.rotation);
        }
    }
}
