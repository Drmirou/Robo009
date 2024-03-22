using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosscode : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private GameObject player;
    public bool chase = false;
    public float HP;
    public int damage = 2;
    public float dash = 1;


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

}
