using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public LayerMask enemyLayer; // Layer mask for detecting enemies
    public float detectionRadius = 5f;
    public Transform detectionPoint; // Point from where detection is done, usually the front of the character

    private void Update()
    {
        // Check for enemy detection
        DetectEnemies();
    }
    void DetectEnemies()
    {
        // Detect enemies within the detection radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(detectionPoint.position, detectionRadius, enemyLayer);

        // If enemies are detected
        if (colliders.Length > 0)
        {
            foreach (Collider2D col in colliders)
            {
                // You can do something with the detected enemies like attacking or triggering an alarm
                Debug.Log("Enemy detected: " + col.gameObject.name);

                // Example:get more information about the enemy
                Enemy enemyScript = col.gameObject.GetComponent<Enemy>();
               if (enemyScript != null)
                {
                   
                }
            }
        }
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