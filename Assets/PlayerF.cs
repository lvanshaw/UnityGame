using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerF : MonoBehaviour
{
    public Transform playerPos;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position + offset;    
    }
}
