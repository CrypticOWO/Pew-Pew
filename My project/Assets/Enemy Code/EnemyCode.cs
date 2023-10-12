using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCode : MonoBehaviour
{
    //variables
    public BoxCollider2D EnemySpawn;      //Defines the grid as a dependant potential spawning space for food

    List<Transform> enemies; //variable to store all the parts of the snake body
    public Transform bodyPrefab;//variable to store the body

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<Transform>();       //Creates a new list
        enemies.Add(transform);                //Add the head of the snake to the list
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count < 4);
        {
            Transform segment = Instantiate(this.bodyPrefab);               //Create a new enemy
            segment.position = RandomPos();                                 //Position it randomly
            enemies.Add(segment);                                           //Add it to the list
        }
    }

    //Function to randomize the position of the enemy and spawning
    private void RandomPos()
    {
        Bounds bounds = EnemySpawn.bounds;                                                //Declare the limits of the space

        float x = Random.Range(bounds.min.x, bounds.max.x);                      //Gives a random value to x within the limit
        float y = Random.Range(bounds.min.y, bounds.max.y);                      //Gives a random value to y within the limit

        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));           //Round the values of x & y while changing position of food
    }

    //Function for destruction every time enemy collides with bullet
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("hit");
        }
    }
}
