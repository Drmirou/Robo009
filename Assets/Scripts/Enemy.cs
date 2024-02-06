using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 0;
    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;

        if (HP < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
    // I love copium yippe!!!!
    
    public Rigidbody2D myRigidBody = null;

    public float MovementSpeedPerSecond = 10.0f;
    public float MovementSign = 1.0f;



    void FixedUpdate()
    {
        
        Vector3 characterVelocity = myRigidBody.velocity;
        
        characterVelocity.x = 0;

       
        characterVelocity += MovementSign * MovementSpeedPerSecond * transform.right.normalized;

      
        myRigidBody.velocity = characterVelocity;


    }
}
// ni f�r byta kod om det inte funkar