using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawning : MonoBehaviour
{
    public BoxCollider2D EnemySpawn;
    List<Transform> enemies;
    public Transform bodyPrefab;
    public float spawnInterval = 1.0f; // Time between spawns

    public static float Score = 0;
    public Text PlayerScore;

    void Start()
    {
        enemies = new List<Transform>();        //Log all existing nemies
        StartCoroutine(SpawnEnemies());         //Enables IEnumerator to function
        PlayerPrefs.SetFloat("Score", 0f);      //Resets the score to be 0
    }

    IEnumerator SpawnEnemies()                  //Allows the use of delays
    {
        while (true)
        {
            Bounds bounds = EnemySpawn.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);

            Transform enemy = Instantiate(this.bodyPrefab);
            enemy.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
            enemies.Add(enemy);

            yield return new WaitForSeconds(spawnInterval);         //Triggers a wait before the next enemy creation
        }
    }

    void Update()
    {
        List<Transform> enemiesToRemove = new List<Transform>();        //New List to keep track of removed enemies

        foreach (Transform enemy in enemies)        //Constantly checks list for the created enemies, foreach because I don't need 'I', much nicer to look at
        {
            if (enemy == null)
            {
                // The enemy has been destroyed or removed from the scene.
                enemiesToRemove.Add(enemy);
            }
        }

        foreach (Transform enemy in enemiesToRemove)
        {
            enemies.Remove(enemy);                      //Removes the logged enemy from old list
            Score++;                                    //Adds to Score
            PlayerPrefs.SetFloat("Score", Score);       //Sets the score to be saved for next scene
            PlayerPrefs.Save();                         //Saves score for next scene
        }

        PlayerScore.text = Score.ToString();
    }
}
