using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 10f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer; 

   
    [SerializeField] float CannonCooldown;
    [SerializeField] float CannonCooldownOnStart;
    public GameObject SimpleBullet;
   
    void Start()
    {
        CannonCooldownOnStart = CannonCooldown;

    }

    void Update()
    {
        CannonCooldown -= Time.deltaTime;
        horizontal = Input.GetAxisRaw("Horizontal");
    }



    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer); 
        if (CannonCooldown > 0)
        {
            CannonCooldown -= Time.deltaTime;
        }
    }

    void OnFire()
    {
        if (CannonCooldown < 0)
        {
            CannonCooldown = CannonCooldownOnStart;

            GameObject Bellet = Instantiate(SimpleBullet, transform.position + new Vector3(0.5f, 0.0f, 0.0f), transform.rotation);
            Destroy(Bellet, 4f);
        }
        
    }
}
