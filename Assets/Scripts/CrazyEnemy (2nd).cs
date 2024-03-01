using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy2 : MonoBehaviour
{

    public float flyingSpeed = 5f; // Speed of the flying enemy
    public int health = 100; // Health points of the flying enemy
    public int attackPower = 20; // Attack power of the flying enemy
    public int Playerhealth;


    // Update is called once per frame
    void Update()
    {
        // Move the enemy horizontally
        transform.Translate(Vector2.left * flyingSpeed * Time.deltaTime);
    }

    // Method to handle when the enemy takes damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Method to handle the death of the enemy
    void Die()
    {
        
        Destroy(gameObject);
    }

    // Method to handle collision with other objects
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the collided object is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            Attack(other.gameObject);
        }
    }
    

    
    void Attack(GameObject player)
    {
        
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
      
       if (playerHealth != null)
        {
          
        //  playerHealth.TakeDamage(attackPower);
        }
    }

    private class PlayerHealth
    {
    }
}

// FREEDOM RAHHHH :BIRD: :BRID:

// might done litte trolling