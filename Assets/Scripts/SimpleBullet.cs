using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // DO stuff if hits enemy

        }

        // Destroy yourself if you hit anything
        Destroy(gameObject);
    }
}
