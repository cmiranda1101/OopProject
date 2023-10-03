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
        maxAttackDelay = 0.8f;
        attackDelay = maxAttackDelay;
        attackRange = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Mathf.Clamp(Vector3.Distance(transform.position, player.transform.position), 0, 100);
        //(Mathf.Abs(gameObject.transform.position.x) - Mathf.Abs(player.transform.position.x), 

        if (distanceFromPlayer > attackRange)
        {
            MoveToPlayer();
            if (attackDelay < maxAttackDelay)
            {
                attackDelay += Time.deltaTime;
            }
        }

        if (distanceFromPlayer <= attackRange)
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
