using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtMouseTest : MonoBehaviour
{
    public Camera cam;
    
    Vector2 mousePos;

    private void Update()
    {
       mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        
    }
}
