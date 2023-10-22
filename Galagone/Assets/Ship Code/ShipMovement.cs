using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    //variable for movement
    public float speed = 0.1f;
    public float xBorder = 6.5f;

    private List<Transform> bullets;  // List to store bullets
    public Transform bodyPrefab;        //variable to store the body

    public GameObject right;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.025f;
        bullets = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < xBorder)    //when RightArrow is pressed
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);   //move right
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -xBorder)    //when LeftArrow is pressed
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y); //move left
        }
        if (Input.GetKeyDown(KeyCode.Space))                                           //when Space is pressed
        {
            Shoot();
        }
    }

    //Function to make the ship shoot
    void Shoot()
    {
        Transform bullet = Instantiate(this.bodyPrefab);
        bullet.position = new Vector2(transform.position.x, transform.position.y);
        bullets.Add(bullet);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            SceneManager.LoadScene("EndScreen");        //Load Game Over
        }
    }
}
