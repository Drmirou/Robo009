using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    private bool z_Interacted = false;
    private bool isPlayerTouching = false;

    // Adjust the layer mask to the layer you set for your player character
    public LayerMask playerLayer;

    private void Update()
    {
        // Check if player is overlapping with the object
        isPlayerTouching = Physics2D.OverlapCircle(transform.position, 0.5f, playerLayer) != null;

        // Check if player is overlapping and pressing the interact key (e.g., KeyCode.E)
        if (isPlayerTouching && Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }
    }

    // Triggered when the player enters the object's collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming player has a "Player" tag
        {
            isPlayerTouching = true;
        }
    }

    // Triggered when the player exits the object's collider
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming player has a "Player" tag
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