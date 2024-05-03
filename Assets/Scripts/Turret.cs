using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class Turret : MonoBehaviour
{
    public float RaycastRange;
    public Transform Target;
    bool Detected = false;

    public GameObject AlarmLight;
    public GameObject gun;
    public GameObject pivot;
    public GameObject bullet;
    public Transform FirePoint;

    [Range(0.1f, 5)]
    public float fireDelay = 1;

    public int AmmoCapacity = 10;
    public int BulletCountUntilReload = 10;
    public float reloadTime = 5;
    private float timeSinceFired = 0;
    public float bulletSpeed = 1;
    private float timeReloaded;

    Vector2 Direction;


    void Start()
    {
        BulletCountUntilReload = AmmoCapacity;
    }

    
    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction= targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,RaycastRange);

        if(timeSinceFired < 6) { timeSinceFired += Time.deltaTime; }

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

        if(Detected) 
        { 
          pivot.transform.up = Direction;
          if (timeSinceFired > fireDelay) 
            {
                timeSinceFired = 0; shoot(); 
            }
        }
        
    }

    private void shoot()
    {
        if (BulletCountUntilReload > 0) 
        {
            GameObject BulletsIns = Instantiate(bullet, FirePoint.position, Quaternion.identity);
            BulletsIns.GetComponent<Rigidbody2D>().AddForce(Direction * bulletSpeed);
            BulletCountUntilReload -= 1;
        }
        else
        reload();
       
    }
    
    private void reload()
    {
        if (timeReloaded > reloadTime)
        {
            BulletCountUntilReload = AmmoCapacity;
        }
        else
        {
            timeReloaded += Time.deltaTime;
        }
    }

     
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pivot.transform.position, RaycastRange);
    }
}
