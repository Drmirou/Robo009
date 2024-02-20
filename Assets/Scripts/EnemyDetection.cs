using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public LayerMask playerLayer; // Layer mask for detecting the player
    public float detectionRadius = 5f; // Radius for detecting the player
    public Transform detectionPoint; // Point from where detection is done
    public float chaseSpeed = 3f; // Speed at which the enemy chases the player

    private Transform player; // Reference to the player's transform
    private bool playerDetected = false; // Flag to track if the player is detected

    void Start() // MEewwowd owowowoow asd kpwas, pad  //huh? //mgmdfpmapewapemsda //huh? // wkdpaksdpokwapd //huh?
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player object
    }

    void Update()
    {
       
        DetectPlayer();

     
        if (playerDetected)
        {
            ChasePlayer();
        }
    }

    void DetectPlayer()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // If the player is within the detection radius, set playerDetected flag to true
        if (distanceToPlayer <= detectionRadius)
        {
            // Check if there are any obstacles between the enemy and the player
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
        // Move towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    // Visualize the detection radius in the editor
    private void OnDrawGizmosSelected()
    {
        if (detectionPoint == null)
            return;


        // Draw a wire circle in the scene view to visualize the detection radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
    }
}

//får åndra "meow" 