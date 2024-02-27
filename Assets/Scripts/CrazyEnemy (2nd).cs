using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy2 : MonoBehaviour
{
    public float flyingSpeed = 5f;
    public int health = 100;
    public int attackPower = 20;
    public int Playerhealth = 1;

    // Update is called once per frame
    void Update()
    {
        // Implement flying movement
        Fly();
    }

    void Fly()
    {
        // Move the enemy horizontally (you can adjust this based on your game)
        transform.Translate(Vector3.right * flyingSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add death effects, play sound, etc.
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Attack(other.gameObject);
        }
    }

    void Attack(GameObject player)
    {
    //    PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
 //       if (playerHealth != null)
        {
   //        playerHealth.TakeDamage(attackPower);
        }
    }
}

// FREEDOM RAHHHH :BIRD: :BRID:

// might done litte trolling