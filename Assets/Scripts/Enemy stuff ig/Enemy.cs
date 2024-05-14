using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f; 
    public int damage = 10;  

    private Rigidbody2D rb;
    private bool movingRight = true;
    public Transform groundDetection;
    public int HP;
    public PlayerHealth playerHealth;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        rb.velocity = (movingRight ? Vector2.right : Vector2.left) * speed;

        
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.1f);
        if (!groundInfo.collider)
        {
            movingRight = !movingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;

        if (HP < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }


}
// ni får byta kod om det inte funkar