using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

    
public class Level2Obstacles : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Speed of movement
    public string groundTag = "Ground"; // Tag to identify the ground object
    public string obstacleTag = "Obstacles"; // Tag to identify the obstacles
    private Vector3 groundPosition;
    private float minX, maxX;

    void Start()
    {
        // Find the ground object using its tag
        GameObject ground = GameObject.FindGameObjectWithTag(groundTag);

        if (ground != null)
        {
            // Get the position and size of the ground object
            groundPosition = ground.transform.position;
            Renderer groundRenderer = ground.GetComponent<Renderer>();
            float halfWidth = groundRenderer.bounds.size.x * 0.5f;

            // Calculate the boundaries based on the ground's position and size
            minX = groundPosition.x - halfWidth;
            maxX = groundPosition.x + halfWidth;
        }
        else
        {
            UnityEngine.Debug.LogError("No ground object found with the specified tag.");
        }
    }

    void Update()
    {
        // Find all objects with the specified tag
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag(obstacleTag);

        foreach (GameObject obstacle in obstacles)
        {
            // Calculate the new position based on the ground's position
            float xPosition = Mathf.PingPong(Time.time * moveSpeed, maxX - minX) + minX;
            Vector3 newPosition = new Vector3(xPosition, obstacle.transform.position.y, obstacle.transform.position.z);
            obstacle.transform.position = newPosition;
        }
    }

    /*
    public float moveSpeed = 2.0f; // Speed of left-right movement
    public float moveDistance = 3.0f; // Maximum distance to move
    public string obstacleTag = "Obstacles"; // Tag to identify the obstacles
    private Vector3 originalPosition;
    private float direction = 1; // 1 for moving right, -1 for moving left

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        /*
        if (gameObject.CompareTag("Obstacles"))
        {
            // Calculate the new position
            Vector3 newPosition = transform.position + (Vector3.right * direction * moveSpeed * Time.deltaTime);

            // Check if the obstacle has moved too far in either direction
            if (Vector3.Distance(originalPosition, newPosition) > moveDistance)
            {
                // Change direction
                direction *= -1;
            }

            // Update the obstacle's position
            transform.position = newPosition;
        }
       
        // Find all objects with the specified tag
        //GameObject[] obstacles = GameObject.FindGameObjectsWithTag(obstacleTag);
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacles");
        foreach (GameObject obstacle in obstacles)
        {
            // Calculate the new position
            Vector3 newPosition = obstacle.transform.position + (Vector3.right * direction * moveSpeed * Time.deltaTime);

            // Check if the obstacle has moved too far in either direction
            if (Vector3.Distance(originalPosition, newPosition) > moveDistance)
            {
                // Change direction
                direction *= -1;
            }

            // Update the obstacle's position
            obstacle.transform.position = newPosition;
        }
         
    }
    */
}
