using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
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

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0,5f );
        }

    }



    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer); 
    }

    void OnFire()
    {
        CannonCooldown = CannonCooldownOnStart;

        GameObject Bellet = Instantiate(SimpleBullet, transform.position, transform.rotation);
        Destroy(Bellet, 4f);
    }
}
