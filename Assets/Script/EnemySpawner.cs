using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    Vector2 WhereToSpawn;
    public float SpawnRate = 5f;
    float NextSpawn = 5f;
    void Start()
    {
        InvokeRepeating("spawn", 5, 5);
    }
     void spawn()
    {
        NextSpawn = Time.time + SpawnRate;
        randX = Random.Range(0, 2f);
        WhereToSpawn = new Vector2(randX, transform.position.y);
        Instantiate(enemy, WhereToSpawn, Quaternion.identity);
    }

    }
