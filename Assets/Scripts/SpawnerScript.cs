using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject objectToSpawn; // The object you want to spawn
    public float spawnInterval = 2f; // Time between spawns
    public float spawnRadius = 5f;   // Spawn radius
    public LayerMask obstacleLayer;  // Layer mask for obstacles

    private void Start()
    {
        // Start spawning objects
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Generate a random position within the spawn radius
            Vector3 randomPosition = transform.position + UnityEngine.Random.insideUnitSphere * spawnRadius;

            // Ensure the object is above the ground (adjust the value as needed)
            randomPosition.y = 0.5f;

            // Instantiate the object at the random position
            GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

            // Check for collisions with obstacles
            Collider[] colliders = Physics.OverlapSphere(randomPosition, 0.5f, obstacleLayer);

            if (colliders.Length > 0)
            {
                // Object collided with an obstacle, so destroy it
                Destroy(spawnedObject);
            }
            else
            {
                // Object didn't collide with any obstacles, continue spawning
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}
