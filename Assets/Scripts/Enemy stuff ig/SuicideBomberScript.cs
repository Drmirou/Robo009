using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBomberScript : MonoBehaviour
{
    public float range;
    public float force;

    public LayerMask affectedEntities;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnDestroy()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, range, affectedEntities);

        foreach (Collider2D obj in objects) 
        
        {
           Vector2 direction = obj.transform.position - transform.position; 
           
           obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
