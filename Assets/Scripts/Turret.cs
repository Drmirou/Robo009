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
            if (Detected == true)
            {
                Detected = false;
                AlarmLight.GetComponent <SpriteRenderer>().color = Color.green;
            }
        }

        if(Detected) { gun.transform.up = Direction; }
    }
     
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
