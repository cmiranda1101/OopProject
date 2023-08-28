using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnEnemyRight();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            SpawnEnemyLeft();
        }
    }

    private void SpawnEnemyRight()
    {
        Vector3 rightSpawnPos = new Vector3(20, 0, -4);
        Instantiate(enemy, rightSpawnPos, enemy.transform.rotation);
    }

    private void SpawnEnemyLeft()
    {
        Vector3 leftSpawnPos = new Vector3(-20, 0, -4);
        Instantiate(enemy, leftSpawnPos, enemy.transform.rotation);
    }
}
