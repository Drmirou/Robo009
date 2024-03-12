using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private bool z_Interacted = false;
    private bool isPlayerTouching = false;

    public LayerMask playerLayer;
    public GameObject itemToGive; // The item to give to the player

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

            // Give the item to the player (You can modify this part based on your inventory system)
            GiveItemToPlayer();

            // Optionally, you can disable the object or perform other actions after interaction
            gameObject.SetActive(false); // Disable the interactable object, for example
        }
    }

    private void GiveItemToPlayer()
    {
        // Instantiate the item and attach it to the player (Modify based on your inventory system)
        GameObject itemInstance = Instantiate(itemToGive, transform.position, Quaternion.identity);
        itemInstance.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
