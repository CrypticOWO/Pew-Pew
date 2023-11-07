using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    float startPosX;
    float startPosY;
    private List<Transform> bullets;  // List to store bullets
    public Transform bodyPrefab;        //variable to store the body

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos;       //create a vector called mousePos
        mousePos = Input.mousePosition;         //change the value of mousePos
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);           //change the value of mousePos
        gameObject.transform.localPosition = new Vector2(mousePos.x, mousePos.y);          //change the positon of the object

        if (Input.GetMouseButtonDown(0))                                           //when LMB is pressed
        {
            Shoot();
        }
    }

    //Function to make the ship shoot
    void Shoot()
    {
        //Establish Bullet Pathfinding
        Vector2 mousePos;       //create a vector called mousePos
        mousePos = Input.mousePosition;         //change the value of mousePos
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);           //change the value of mousePos
        Vector2 direction = mousePos - (Vector2)transform.position;
        direction.Normalize();

        //Make the bullet
        Transform bullet = Instantiate(this.bodyPrefab);
        bullet.position = new Vector2(transform.position.x, transform.position.y);
        bullets.Add(bullet);
    }
}
