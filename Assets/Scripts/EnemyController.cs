using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private float speed;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile"))
        {
            Debug.Log("enemy shot");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
