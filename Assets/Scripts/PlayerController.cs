using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    public bool facingRight;
    private float leftBound = -10.5f;
    private float rightBound = 10.5f;

    public GameObject projectile;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if(transform.position.x <= leftBound) 
        {
            transform.position = new Vector3 (-10.5f, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= rightBound)
        {
            transform.position = new Vector3 (10.5f, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void MoveRight()
    {
        if (facingRight == false)
        {
            transform.Rotate(0, 180, 0);
            facingRight = true;
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void MoveLeft()
    {
        if (facingRight == true)
        {
            transform.Rotate(0, 180, 0);
            facingRight = false;
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void Shoot()
    {
        Instantiate(projectile, transform.position, player.transform.rotation);
    }
}
