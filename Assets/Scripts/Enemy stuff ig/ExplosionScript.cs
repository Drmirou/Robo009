using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private Collider2D myCollider;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();

        if (myCollider != null)
        {
            myCollider.enabled = false;
        }

        Invoke("DealDamage", 0.5f);

    }

    void DealDamage()
    {
        myCollider.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            

        }
    }
}


