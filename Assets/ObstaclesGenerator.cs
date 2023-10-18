using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
     public GameObject objectToSpawn; // The object you want to spawn
    public float spawnInterval = 2f; // Time between spawns
    public Transform playerTransform; // Reference to the player's transform
    public float minDistanceToPlayer = 5f; // Minimum distance from the player
    public LayerMask obstacleLayer;  // Layer mask for obstacles
    public float obstacleLerpSpeed = 2f; // Lerp speed for obstacle movement
    public float obstacleRotationSpeed = 30f; // Rotation speed for obstacle rotation

    private Vector3[] spawnPositions; // Array of predefined spawn positions
    private int currentSpawnIndex = 0; // Index of the current spawn position

    private void Start()
    {
        // Define your spawn positions here (adjust as needed)
        spawnPositions = new Vector3[]
        {
            new Vector3(0, 0.5f, 10),
            new Vector3(3, 0.5f, 20),
            new Vector3(-3, 0.5f, 30),
            // Add more positions as needed
        };

        // Start spawning objects
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (currentSpawnIndex < spawnPositions.Length)
        {
            Vector3 spawnPosition = spawnPositions[currentSpawnIndex];

            // Check if the spawn position is far enough from the player
            if (Vector3.Distance(spawnPosition, playerTransform.position) >= minDistanceToPlayer)
            {
                // Instantiate the object at the spawn position
                GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

                // Check for collisions with obstacles
                Collider[] colliders = Physics.OverlapSphere(spawnPosition, 0.5f, obstacleLayer);

                if (colliders.Length > 0)
                {
                    // Object collided with an obstacle, so destroy it
                    Destroy(spawnedObject);
                }
                else
                {
                    // Object didn't collide with any obstacles
                    currentSpawnIndex++; // Move to the next spawn position
                    yield return new WaitForSeconds(spawnInterval);
                }
            }
            else
            {
                // The spawn position is too close to the player, move to the next position
                currentSpawnIndex++;
            }
        }
    }

    private void Update()
    {
        // Rotate all objects with the "Obstacle" tag using lerp
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacles");

        foreach (var obstacle in obstacles)
        {
            // Calculate the target rotation (e.g., rotate around the Y-axis)
            Quaternion targetRotation = Quaternion.Euler(0f, obstacle.transform.rotation.eulerAngles.y + obstacleRotationSpeed * Time.deltaTime, 0f);

            // Lerp the rotation
            obstacle.transform.rotation = Quaternion.Lerp(obstacle.transform.rotation, targetRotation, Time.deltaTime * obstacleLerpSpeed);
        }
    }
}
