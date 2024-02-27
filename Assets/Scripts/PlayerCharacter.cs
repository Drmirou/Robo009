using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private float horizontal;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpingPower = 4f;   
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    CannonScript cannonscript;

    private void Start()
    {
        cannonscript = FindObjectOfType<CannonScript>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
       
        if(coyoteTimeCounter > 0 && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
     
        if (Input.GetButtonUp("Jump") && rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0, 5f);

            coyoteTimeCounter = 0f;

        }

        Flip();
    }

    private void Flip()
    {
      
       // Fix, if mouse position = a certain value the character turns to left or right
   
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.3f, groundLayer);

    }

    void OnFire()
    {

        cannonscript.CannonFire();
        

    }

}
