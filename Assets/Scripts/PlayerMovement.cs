using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform orientation;
    //public float forwardForce = 700f;
    //public float sidewaysForce = 700f;

    [Header("Camera Roatation Movement of Player")]
    public float speed = 6f;

    [Header("Movement")]
    public float moveSpeed = 7f;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    [Header("Jump")]
    public float jumpForce = 21;
    public float airMultiplier = 0.4f;
    bool readyToJump = true;
    public float jumpCooldown = 0.25f;
    public KeyCode jumpKey = KeyCode.Space;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void OnCollisionEnter() {
        UnityEngine.Debug.Log("we hit something");
    }
    void Update() {

        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();

        SpeedControl();

        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

    }
    void MyInput() {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

       
        //when to Jump
        if (Input.GetKey(jumpKey) && grounded && readyToJump) {
            readyToJump = false;
            Jump();
            Invoke(nameof(RestJump), jumpCooldown);
        }

        
    }
    void FixedUpdate()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        //on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        //in air
        if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        /*
         if (Input.GetKey("q"))
        {   //jump
            rb.AddForce(transform.up * 1 , ForceMode.Impulse);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
        */

    }

    private void SpeedControl() {
        //if speed is fast then we update the value of the rigidbody velcoity
        Vector3 flatVal = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVal.magnitude > moveSpeed) {
            Vector3 limitedVal = flatVal.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVal.x, rb.velocity.y, limitedVal.z);
        }
    }

    private void Jump() {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void RestJump() {
        readyToJump = true;
    }

}
