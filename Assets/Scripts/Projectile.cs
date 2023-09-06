using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        projectileSpeed = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * projectileSpeed * Time.deltaTime;
    }
}
