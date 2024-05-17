using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class SuicideBomberScript : MonoBehaviour
{
    public float explosionRange;
    public float explosionForce;
    public LayerMask playerLayer;
    public float detectionRadius = 5f;
    public Transform detectionPoint;
    private Transform player;
    private bool playerDetected = false;
    public float chaseSpeed = 3f;
    public Transform playerPos;
    public float jumpForce;
    public int jumpCooldown;
    public float timeSincejumped;

    Vector2 playerHeadPos;

    public LayerMask affectedEntities;
    Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        DetectPlayer();

        if (timeSincejumped < jumpCooldown)
        { timeSincejumped += Time.deltaTime; }


        if (playerDetected)  
        {
            ChasePlayer();
           
            if(timeSincejumped >= jumpCooldown)        // change to 50 percent chance to jump
            {
                Jump();
                timeSincejumped = 0;
            }
        }
    }

    void DetectPlayer()
    {
       
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        
        if (distanceToPlayer <= detectionRadius)
        {
            RaycastHit2D hit = Physics2D.Raycast(detectionPoint.position, player.position - detectionPoint.position, distanceToPlayer, playerLayer);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                playerDetected = true;
            }
            else
            {
                playerDetected = false;
            }
        }
        else
        {
            playerDetected = false;
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    void Jump()
    {
       Vector2 playerHeadPos = playerPos.transform.position - transform.position;
        

        rb.AddForce(playerHeadPos.normalized * jumpForce, ForceMode2D.Impulse);
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
     
        if (detectionPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))  
        {
            Destroy(gameObject);
        }
    }
    
    private void OnDestroy()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, explosionRange, affectedEntities);

        foreach (Collider2D obj in objects)

        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * explosionForce); // Add explosion effect and whatever else on death, like damage to player
        }
    }
}
