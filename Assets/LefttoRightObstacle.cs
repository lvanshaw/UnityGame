using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LefttoRightObstacle : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float moveDistance = 3.0f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position
        Vector3 newPosition = transform.position + (Vector3.right * moveSpeed * Time.deltaTime);

        // Check if the obstacle has moved too far to the right
        if (newPosition.x - originalPosition.x > moveDistance)
        {
            newPosition = originalPosition;
        }

        // Update the obstacle's position
        transform.position = newPosition;
    }
}
