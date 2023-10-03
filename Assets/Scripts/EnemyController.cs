using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected GameObject player;
    public float speed;
    public int health;
    public int damage;
    public float attackDelay;
    public float distanceFromPlayer;

    public PlayerController playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = player.GetComponent<PlayerController>();   
    }

    void Awake()
    {
        player = GameObject.Find("Player");
        speed = 7.0f;
        health = 2;
        damage = 2;
        attackDelay = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Mathf.Abs(Mathf.Abs(gameObject.transform.position.x) - Mathf.Abs(player.transform.position.x));
        if (distanceFromPlayer < 0)
        {
            distanceFromPlayer *= -1;
        }
        MoveToPlayer();
        if (distanceFromPlayer <= 2)
        {
            Attack();
        }
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

    public void Attack()
    {
        attackDelay -= Time.deltaTime;
        if (attackDelay <= 0)
        {
            DealDamage();
            attackDelay = 0.5f;
            Debug.Log("dealt damage");
        }
    }

    public void DealDamage()
    {
        playerStats.health -= damage;
    }
}
