using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    
    public int AddHealth = 1;
    public int HP = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       var PlayerScript = collision.gameObject.GetComponent<PlayerCharacter>();
       if (PlayerScript != null)

        {
           PlayerScript.HP += AddHealth;
            AddHealth = 0;
            GameObject.Destroy(gameObject);
        }
    }
}
// Kan göra vad ni vill med powerup