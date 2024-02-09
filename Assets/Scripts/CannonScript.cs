using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    private Camera cam;
    public GameObject SimpleBullet;
    [SerializeField] float CannonCooldown;
    [SerializeField] float CannonCooldownOnStart;
    public Transform bulletSpawner;
    
    
    Vector3 mousePos;


    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        CannonCooldownOnStart = CannonCooldown;
        CannonCooldown = 0;
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
        if (CannonCooldown <= 0)
        {
            CannonCooldown = CannonCooldownOnStart;

            Instantiate(SimpleBullet, bulletSpawner.position, Quaternion.identity);
            Rigidbody2D BelletRB = SimpleBullet.GetComponent<Rigidbody2D>();
            
            
            Destroy(SimpleBullet, 10f);
        }
    }
}
