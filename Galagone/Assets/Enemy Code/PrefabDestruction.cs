using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabDestruction : MonoBehaviour
{
    public float speed = 0.015f;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.0005f;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        var step = .5f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);
    }

    //Function for destruction every time enemy collides with bullet
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);                                                // Destroy the enemy when it collides with a bullet
        }
    }
}
