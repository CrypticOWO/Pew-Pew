using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour

{
    public BoxCollider2D EnemySpawn;
    List<Transform> enemies;
    public Transform bodyPrefab;
    public float spawnInterval = 1.0f; // Add 'f' to specify it as a float

    void Start()
    {
        enemies = new List<Transform>();
        enemies.Add(transform);
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Bounds bounds = EnemySpawn.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);

            Transform Enemy = Instantiate(this.bodyPrefab);
            Enemy.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
            enemies.Add(Enemy);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void Update()
    {

    }
}

