using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
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

    SmgScript smgscript;
    CannonScript cannonscript;
    bool FirePressed = false;

    private void Awake()
    {
        cannonscript = FindObjectOfType<CannonScript>();
        smgscript = FindObjectOfType<SmgScript>();

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

        if (coyoteTimeCounter > 0 && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            coyoteTimeCounter = 0f;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0, 5f);
        }
        Flip();
        if (FirePressed)
        {
            cannonscript.CannonFire();
            smgscript.GunShoot();
            
        }
    }
    public GameObject PLayerBody = null;
    private void Flip()
    {
        Vector3 mouseCameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseCameraPos.z = 0f;

        if (transform.position.x > mouseCameraPos.x)
        {
            if (PLayerBody.transform.rotation != Quaternion.Euler(0, -180, 0)) { PLayerBody.transform.rotation = Quaternion.Euler(0, 180, 0); }

        }
        else
        {
            if (PLayerBody.transform.rotation != Quaternion.Euler(0, 0, 0)) { PLayerBody.transform.rotation = Quaternion.Euler(0, 0, 0); }

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

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundcheck.position, 0.3f);
    }

        void OnFire(InputValue value)
    {

        if (value.isPressed)
        {
            FirePressed = true;

        }
        else 
        {
            FirePressed = false;
        }


    }

}
