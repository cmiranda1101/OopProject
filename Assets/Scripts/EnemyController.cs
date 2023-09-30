using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected GameObject player;
    public float speed;
    public int health;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        speed = 7.0f;
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            TakeDamage();
        }
    }

    protected void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public virtual void TakeDamage()
    {
        health -= 1;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
