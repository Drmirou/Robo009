using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private Collider2D myCollider;
    PlayerCharacter character;

    public float damage;

    private void Awake()
    {
        GetComponent<Collider2D>().enabled = false;
    }
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
            character=other.gameObject.GetComponent<PlayerCharacter>();
            character.HP -= damage;

        }
    }
}


