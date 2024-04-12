using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamages : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
