using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //variable for movement
    public float speed = 0.1f;
    public float xBorder = 6.5f;

    public GameObject right;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.025f;
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
    }
}
