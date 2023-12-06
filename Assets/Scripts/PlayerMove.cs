using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //animator
    public Animator anim;
    string IDLE = "ground";
    
    // Start is called before the first frame update
    void Start()
    {
        //acessing animator values from this object
        anim = GetComponent<Animator>();
    }
    public float moveSpeed = 6f;
  
    void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
        
        if (Input.GetKey(KeyCode.W)) {
            anim.SetBool(IDLE, false);
            inputVector.y = +1;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool(IDLE, false);
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool(IDLE, false);
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool(IDLE, false);
            inputVector.x = +1;
        }

        if (!Input.anyKey)
        {
            anim.SetBool(IDLE, true);
        }
        
        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * Time.deltaTime * moveSpeed;
        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.position, moveDir, Time.deltaTime * rotationSpeed);
    }
}
