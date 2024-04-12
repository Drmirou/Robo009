using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmgScript : MonoBehaviour
{
    private Camera cam;
    public GameObject smgBullet;
    [SerializeField] float GunCooldown;
    [SerializeField] float GunCooldownOnStart;
    [SerializeField] float PlayerCannonDistance = 0.9f;
    public Transform bulletSpawner;

    Vector3 mousePos;
   public Transform playerPos;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        GunCooldownOnStart = GunCooldown;
        GunCooldown = 0;
/*        playerPos = GameObject.Find("Player").GetComponent<Transform>()*/;
    }
    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (GunCooldown > 0)
        {
            GunCooldown -= Time.deltaTime;
        }
        else
        {
            GunCooldown = 0;
        }

    }

    public void GunShoot()
    {
        float dist = Vector2.Distance(mousePos, playerPos.position);

        if (dist > PlayerCannonDistance)
        {
            if (GunCooldown <= 0)
            {
                GunCooldown = GunCooldownOnStart;

                GameObject bellet = Instantiate(smgBullet, bulletSpawner.position, bulletSpawner.rotation);
                Rigidbody2D BelletRB = smgBullet.GetComponent<Rigidbody2D>();


                Destroy(bellet, 10f);
            }
        }
    }
 }