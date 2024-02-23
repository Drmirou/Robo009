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
    [SerializeField] bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;

    private float coyoteTime;
    private float coyoteTimeCounter;

    CannonScript cannonscript;

    private void Start()
    {
        cannonscript = FindObjectOfType<CannonScript>();
    }

    void Update()
    {
       if(IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        if(coyoteTimeCounter > 0 && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.x > 0)
        {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0, 5f);
        }

        Flip();
    }

    private void Flip()
    {

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
