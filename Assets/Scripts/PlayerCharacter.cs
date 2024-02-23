using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    CannonScript cannonscript;

    private void Start()
    {
        cannonscript = FindObjectOfType<CannonScript>();
    }

    void Update()
    {
       
        horizontal = Input.GetAxisRaw("Horizontal");
        if(IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
        }
        else
        {
            if (Input.GetButtonUp("Jump") && rb.velocity.x > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0, 5f);
            }
        }

    

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
