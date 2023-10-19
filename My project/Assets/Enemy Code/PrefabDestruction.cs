using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabDestruction : MonoBehaviour
{
    public float speed = 0.015f;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.0015f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed);
    }

    //Function for destruction every time enemy collides with bullet
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);                                                // Destroy the enemy when it collides with a bullet
            Debug.Log("Enemy destroyed");
        }
    }
}
