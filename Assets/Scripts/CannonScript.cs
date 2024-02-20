using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    private Camera cam;
    public GameObject SimpleBullet;
    [SerializeField] float CannonCooldown;
    [SerializeField] float CannonCooldownOnStart;
    [SerializeField] float PlayerCannonDistance = 0.9f;
    public Transform bulletSpawner;

    
    
    
    Vector3 mousePos;
    Transform playerPos;


    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        CannonCooldownOnStart = CannonCooldown;
        CannonCooldown = 0;
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void Update()
    {
       mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
       Vector3 rotation = mousePos - transform.position;
       float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
       transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (CannonCooldown > 0)
        {
            CannonCooldown -= Time.deltaTime;
        }
        else
        {
            CannonCooldown = 0;
        }
        
    }

    public void CannonFire()
    {
       float dist = Vector2.Distance(mousePos, playerPos.position);
        Debug.Log(dist);
        if (dist > PlayerCannonDistance)
        {
            if (CannonCooldown <= 0)
            {
                CannonCooldown = CannonCooldownOnStart;

                GameObject bullet = Instantiate(SimpleBullet, bulletSpawner.position, bulletSpawner.rotation);
                Rigidbody2D BelletRB = SimpleBullet.GetComponent<Rigidbody2D>();


                Destroy(bullet, 10f);
            }
        }
    }


}
