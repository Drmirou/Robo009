using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private bool z_Interacted = false;
    private bool isPlayerTouching = false;

   
    public LayerMask playerLayer;

    private void Update()
    {
       

        isPlayerTouching = Physics2D.OverlapCircle(transform.position, 0.5f, playerLayer) != null;

        
        if (isPlayerTouching && Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }
    }

  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerTouching = true;
        }
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerTouching = false;
        }
    }

    protected virtual void OnInteract()
    {
        if (!z_Interacted && isPlayerTouching)
        {
            z_Interacted = true;
            Debug.Log("INTERACT WITH " + name);
        }
    }
}