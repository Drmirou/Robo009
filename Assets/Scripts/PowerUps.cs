using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public int AddHealth = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        {
            GameObject.Destroy(gameObject);
        }
    }
}