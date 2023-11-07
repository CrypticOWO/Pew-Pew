using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public Vector2 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.025f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 transform.position += 5f;

        // Remove bullets when they go off-screen
        if (transform.position.y > 5f)
        {
            Destroy(gameObject); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);       // Destroy the bullet when it collides with an enemy
        }
    }
}
