using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    private Camera cam;
    public GameObject SimpleBullet;
    [SerializeField] float CannonCooldown;
    [SerializeField] float CannonCooldownOnStart;
    
    
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

            GameObject Bellet = Instantiate(SimpleBullet, transform.position + new Vector3(0.5f, 0.0f, 0.0f), transform.rotation);
            Rigidbody2D BelletRB = Bellet.GetComponent<Rigidbody2D>();
            
            
            Destroy(Bellet, 4f);
        }
    }
}
