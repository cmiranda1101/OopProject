using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : EnemyController
{
    void Awake()
    {
        player = GameObject.Find("Player");
        speed = 3.5f;
        health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    protected new void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            TakeDamage();
        }
    }
    public override void TakeDamage()
    {
        health -= 1;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
