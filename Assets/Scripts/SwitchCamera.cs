using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]
    Camera firstPersonCamera;
    [SerializeField]
    Camera thirdPersonCamera;
    [SerializeField]
    Camera backPersonCamera;
    private bool switchCam = false;
    private bool backCam = false;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera.GetComponent<Camera>().enabled = false;
        thirdPersonCamera.GetComponent<Camera>().enabled = true;
        backPersonCamera.GetComponent<Camera>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t")) {
            switchCam = !switchCam;
            backCam = false;
        }
        if (Input.GetKeyDown("b")) {
            switchCam = false;
            backCam = true;
        }
        if (switchCam == true)
        {
            firstPersonCamera.GetComponent<Camera>().enabled = true;
            thirdPersonCamera.GetComponent<Camera>().enabled = false;
            backPersonCamera.GetComponent<Camera>().enabled = false;
        }
        else if (backCam == true)
        {
            firstPersonCamera.GetComponent<Camera>().enabled = false;
            thirdPersonCamera.GetComponent<Camera>().enabled = false;
            backPersonCamera.GetComponent<Camera>().enabled = true;
        }
        else {
            firstPersonCamera.GetComponent<Camera>().enabled = false;
            thirdPersonCamera.GetComponent<Camera>().enabled = true;
            backPersonCamera.GetComponent<Camera>().enabled = false;
        }
    }
}
