using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float projectileSpeed;
    private float rightBound = 20.0f;
    private float leftBound = -20.0f;
    // Start is called before the first frame update
    void Start()
    {
        projectileSpeed = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * projectileSpeed * Time.deltaTime;

        if (transform.position.x <leftBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
}
