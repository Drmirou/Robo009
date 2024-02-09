using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{        
    private Collider2D z_Collider;
    private ContactFilter2D z_filter;
    private List<Collider2D> z_CollidedObjects; 

    private void Start()
    {
        z_Collider = GetComponent<Collider2D>(); 
    }

    private void Update()
    {
        z_Collider.OverlapCollider(z_filter, z_CollidedObjects);
        foreach(var o in  z_CollidedObjects) 
        {
            Debug.Log("Collided with" + o.name);
        }
    }
}
