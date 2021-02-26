using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Variables
    [SerializeField] GameObject[] asteroidPrefabs;
    private float spawnRangeX = 7.0f;
    private float spawnHeight = 6.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //calling the spawn method with a start delay and a repeat time scope
        InvokeRepeating("SpawnRandomAsteroids", startDelay, spawnInterval);
    }

    //Spawning random asteroids from the array in random positions 
    void SpawnRandomAsteroids()
    {
        int asteroidIndex = Random.Range(0, asteroidPrefabs.Length);
        Vector2 spawnPosition = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), spawnHeight);

        Instantiate(asteroidPrefabs[asteroidIndex], spawnPosition, Quaternion.identity);
    }
}
