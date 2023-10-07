using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inheritance
public class Scout : EnemyController
{
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");

        //Polymorphism
        speed = 10.0f;
        health = 1;
        damage = 1;
        maxAttackDelay = 0.25f;
        attackDelay = maxAttackDelay;
        attackRange = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Mathf.Clamp(Vector3.Distance(transform.position, player.transform.position), 0, 100);
         

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
