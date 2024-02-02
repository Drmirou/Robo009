using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 10f;
    public bool isFacingRight = true;

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
        if (CannonCooldown > 0)
        {
            CannonCooldown -= Time.deltaTime;
        }
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
        if (CannonCooldown < 0)
        {
            CannonCooldown = CannonCooldownOnStart;

            GameObject Bellet = Instantiate(SimpleBullet, transform.position + new Vector3(0.5f, 0.0f, 0.0f), transform.rotation);
            Rigidbody2D BelletRB = Bellet.GetComponent<Rigidbody2D>();
            if(isFacingRight == true )
            {
                BelletRB.velocity += new Vector2(2f, 0);
            }
            else
            {
                BelletRB.velocity += new Vector2(-2f, 0);
            }
            Destroy(Bellet, 4f);
        }
        
    }
}
