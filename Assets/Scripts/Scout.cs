using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : EnemyController
{
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        speed = 10.0f;
        health = 1;
        damage = 1;
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
