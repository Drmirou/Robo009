using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float Range;
    public Transform Target;
    bool Detected = false;

    public GameObject AlarmLight;
    public GameObject gun;
    public GameObject pivot;
    public GameObject bullet;

    public float fireSpeed = 1;
    public float BulletCountUntilReload = 10;
    public float reloadTime = 5;

    Vector2 Direction;


    void Start()
    {
        
    }

    
    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction= targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                { Detected = true; AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;}
            }
        }  
        else
        {

                Detected = false;
                AlarmLight.GetComponent <SpriteRenderer>().color = Color.green;

        }

        if(Detected) { pivot.transform.up = Direction; }
    }
     
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pivot.transform.position, Range);
    }
}
