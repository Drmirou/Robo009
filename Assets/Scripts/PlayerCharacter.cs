using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PlayerCharacter : MonoBehaviour
{
    public PlayerData CurrentPlayerData = null;
    private float horizontal;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpingPower = 4f;
    public float HP = 1.0f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Vector3 mousePosition;
    [SerializeField] private float sprintingMultiplier;

    private Animator anim;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    public GameObject SMGweapon;
    public GameObject CannonWeapon;
   
    SmgScript smgscript;
    CannonScript cannonscript;
    bool FirePressed = false;
    bool IsRunning = false;
    bool IsSprinting = false;

    private void Awake()
    {
        cannonscript = FindObjectOfType<CannonScript>();
        smgscript = FindObjectOfType<SmgScript>();
        anim=GetComponentInChildren<Animator>();

        if (SMGweapon.activeInHierarchy) { Debug.Log("i has smg script"); } else { Debug.Log("no smg :("); }

    }

    void Update()
    {
        if (rb.velocity.x > 0 || rb.velocity.x < 0) { IsRunning = true; } else { IsRunning = false; }
        if (Input.GetKey(KeyCode.LeftShift)) { IsSprinting = true; } else { IsSprinting = false; }


        anim.SetBool("IsSprinting", IsSprinting);
        anim.SetBool("IsRunning", IsRunning);

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
            if (smgscript != null) { smgscript.GunShoot(); }
            if (cannonscript != null) { cannonscript.CannonFire(); }
        }
       
        switch (HP)
        {
            case 0:
                //nu �r d�d
                break;
            case 1:
                //nu n�stan d�d
                break;

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
        if (IsSprinting) {
        rb.velocity = new Vector2(horizontal * speed * sprintingMultiplier, rb.velocity.y); }
        else 
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
