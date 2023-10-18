using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerM : MonoBehaviour
{
    public Rigidbody rb;
    public Transform orientation;

    public float forwardForce = 700f;
    public float sidewaysForce = 700f;


    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    [Header("Movement")]
    public float moveSpeed = 4f;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }


    void Update() {
        //Movement();
        MyInput();
    }
    void FixedUpdate()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        //Check if Its falls 
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }


    void MyInput()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

        /*
        void Movement() {
            if (Input.GetKey("q"))
            {   //jump
                rb.AddForce(transform.up * 1, ForceMode.Impulse);
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
        }
        */

    

}
