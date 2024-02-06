using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtMouseTest : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D myRigidbody;
    
    
    Vector2 mousePos;

    private void Update()
    {
       mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        Vector2 aimDirection = mousePos - myRigidbody.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        myRigidbody.rotation = angle;
    }
}
