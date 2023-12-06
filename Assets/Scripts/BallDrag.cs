using UnityEngine;

public class BallDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Rigidbody rb;
    private Plane plane;
    private bool isActive = false;
    private float planeWidth = 5f; // Set the width of your plane here
    private float planeLength = 5f; // Set the length of your plane here

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        plane = new Plane(Vector3.up, transform.position);
    }

    void OnMouseDown()
    {
        isDragging = true;
        if (!isActive)
        {
            rb.isKinematic = false;
            isActive = true;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
    void Update()
    {
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;
            if (plane.Raycast(ray, out distance))
            {
                Vector3 hitPoint = ray.GetPoint(distance);
                Vector3 newPosition = new Vector3(hitPoint.x, transform.position.y, hitPoint.z);
                rb.MovePosition(newPosition);
            }
        }
    }

    void LateUpdate()
    {
        // Ensure the ball stays on the surface of the plane and doesn't go above it
        Vector3 newPosition = transform.position;
        float distanceToPlane;
        if (plane.Raycast(new Ray(transform.position, Vector3.down), out distanceToPlane))
        {
            newPosition.y = Mathf.Clamp(newPosition.y, distanceToPlane, float.MaxValue);
            rb.MovePosition(newPosition);
        }
    }
}
