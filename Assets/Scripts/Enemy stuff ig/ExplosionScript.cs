using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private Collider myCollider;

    void Start()
    {
        myCollider = GetComponent<Collider>();
      
        if (myCollider != null)
        {
            myCollider.enabled = false;
        }

        Invoke("DealDamage",0.5f);
            
    }

   void DealDamage()
    {

    }
}
