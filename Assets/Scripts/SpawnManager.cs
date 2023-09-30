using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject enemy;
    public GameObject[] enemies;
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

        //if (Input.GetKeyDown(KeyCode.O))
        {
            //Instantiate(enemy, PickRandomSpawn(), enemy.transform.rotation);
        }

        //if (Input.GetKeyDown(KeyCode.P))
        {
            //Instantiate(scout, PickRandomSpawn(), scout.transform.rotation);
        }

        //if (Input.GetKeyDown(KeyCode.I))
        {
            //Instantiate(knight, PickRandomSpawn(), knight.transform.rotation);
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

    private GameObject PickRandomEnemy()
    {
        int enemyDiceRoll = Random.Range(0, 3);
        return enemies[enemyDiceRoll];
    }

    void SpawnEnemyWave(int spawnCredits)
    {
        for (int i = 0; i < spawnCredits; i++)
        {
            Instantiate(PickRandomEnemy(), PickRandomSpawn(), Quaternion.identity);
        }
    }
}
