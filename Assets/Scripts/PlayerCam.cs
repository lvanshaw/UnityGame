using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform orientation;
    

    public float sensX = 200;
    public float sensY = 200;

    float xRotation;
    float yRotation;





    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position + offset;

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

       

    }
}
