using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPlayerView : MonoBehaviour
{


    public float turnSpeed = 4.0f;
    public GameObject target;
    public GameObject targetOrientation;
    private float targetDistance;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 0.0f;
    private float rotX;
    private float y;
    Vector3 moveDirection;
    [Header("Movement")]
    public float moveSpeed = 10f;

    //public Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
        targetDistance = Vector3.Distance(transform.position, target.transform.position);
    }
    void Update()
    {


        // get the mouse inputs
        y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;
        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);
        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
        // move the camera position
        transform.position = target.transform.position - (transform.forward * targetDistance);


        // Move the target object based on the camera's forward direction
        moveDirection = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");

        //setting orientation gameobject rotation 
        target.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + y, 0);

        targetOrientation.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + y, 0);

        //trying to change the position here itself
        //target.transform.position += moveDirection * moveSpeed * Time.deltaTime;
        //rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    }
    /*
    void LateUpdate() {
        targetOrientation.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + y, 0);

    }
    */
}
