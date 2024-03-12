using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; 
    private int currentHealth;   

    void Start()
    {
        currentHealth = maxHealth;
    }

   
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; 

        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

   
    void Die()
    {
     
        gameObject.SetActive(false);
        Debug.Log("Player has died!");
    }
}