
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform cameraPosition;
    //public Transform playerOrientation;
    public Vector3 offset = new Vector3(0, 0, -3).normalized;

    bool switchCam = false;
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position+offset;
        //playerOrientation.rotation = transform.rotation;
        if (Input.GetKey("t") ) { 
            switchCam = !switchCam;
            
        }
        if (switchCam == true) {
            transform.position = cameraPosition.position + offset;
        }
    }
}
