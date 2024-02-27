using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PlayerCharacter : MonoBehaviour
{
    public PlayerData CurrentPlayerData = null;
    private float horizontal;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpingPower = 4f;
    [SerializeField] float HP = 1.0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector3 mousePosition;


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
        Vector3 mouseCameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseCameraPos.z = 0f;

        if(transform.position.x > mouseCameraPos.x) {
           if(transform.rotation !=  Quaternion.Euler(0, -180, 0)) { transform.rotation = Quaternion.Euler(0, 180, 0); }
           
        }   else
        {
           if (transform.rotation != Quaternion.Euler(0, 0, 0)) { transform.rotation = Quaternion.Euler(0, 0, 0); }

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
