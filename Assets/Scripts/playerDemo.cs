using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class playerDemo : MonoBehaviour
{
    private bool isDragging = true;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnMouseDown()
    {
        
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }
    void OnMouseup()
    {
        isDragging = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousepos);
    }
}
