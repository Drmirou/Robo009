using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosscode : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private GameObject player;
    public bool chase = false;
    public float HP;
    public int damage = 2;
    public float speed;
    public float dashCooldown = 10f; 
    public int maxDashes = 3;
    public float dashSpeed = 10f; 
    public float dashDuration = 0.5f; 
    private bool isDashing = false; 
    private int remainingDashes;
    private float dashTimer = 2f; 


    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;

        if (HP < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }





    // You guys are such a winners on god!!!
}
