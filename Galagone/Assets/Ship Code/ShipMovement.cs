using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    //variable for movement
    public float speed = 0.1f;
    public float xBorder = 6.5f;
    public float yBorder = 4.5f;

    public GameObject right;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.025f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x < xBorder)    //when D is pressed
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);   //move right
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -xBorder)    //when A is pressed
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y); //move left
        }
        if (Input.GetKey(KeyCode.W) && transform.position.y < yBorder)    //when W is pressed
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed);   //move Up
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y > -yBorder)    //when S is pressed
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed); //move Down
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            SceneManager.LoadScene("EndScreen");        //Load Game Over
        }
    }
}
    
