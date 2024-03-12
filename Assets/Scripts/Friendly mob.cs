using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Friendly_Mob : MonoBehaviour
{
    public string[] dialogueLines;
    public GameObject dialoguePanel;
    public Text dialogueText;
    public int index;

    public float wordspeed;
    public bool playerIsClose;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        { 
     //    if(dialoguePanel.
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;

        }
    }
}

 
