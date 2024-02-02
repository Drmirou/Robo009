using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask groundLayer;  // The layer(s) representing the ground
    public float groundCheckRadius = 0.2f;  // Radius of the circle used for ground check
    public bool isGrounded;  // Flag indicating whether the object is grounded

    void Update()
    {
        // Perform ground check
        isGrounded = CheckGround();
    }

    bool CheckGround()
    {
        // Check if the circle overlaps with the ground layer
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, groundCheckRadius, groundLayer);

        // If any colliders are found, the object is considered grounded
        return colliders.Length > 0;
    }

    // Optionally, you can draw the ground check circle in the scene view for debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }
}
