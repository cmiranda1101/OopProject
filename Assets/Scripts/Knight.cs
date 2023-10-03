using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : EnemyController
{
    void Awake()
    {
        player = GameObject.Find("Player");
        speed = 3.75f;
        health = 4;
        damage = 3;
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = player.transform.position.x - gameObject.transform.position.x;
        MoveToPlayer();
        if (distanceFromPlayer <= 2)
        {
            Attack();
        }
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
