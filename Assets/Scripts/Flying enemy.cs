using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy2 : MonoBehaviour
{
    public UnityEngine.Transform startingPoint;
    private GameObject player;
    public float flyingSpeed;
    public bool chase = false;
    public float HP;

    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;

        if (HP < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

     void Update()
    {
        if (player == null)
            return;
        if (chase == true)
            Chase();
        else
            ReturnStartPoint();
        Flip();
    }
    private void Chase()  
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, flyingSpeed*Time.deltaTime);
        if (Vector2.Distance(transform .position, player.transform .position )<= 0.5f)
        {
            //change spped, shoot,animation
        }
        else
        {
            //reset variable 
        }

    }
    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position ,startingPoint.position, flyingSpeed = Time.deltaTime);
    }
    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
     

}

// FREEDOM RAHHHH :BIRD: :BRID:

// might done litte trolling
