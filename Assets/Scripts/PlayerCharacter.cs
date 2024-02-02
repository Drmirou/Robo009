using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float CannonCooldown;
    [SerializeField] float CannonCooldownOnStart;
    public GameObject SimpleBullet;
   
    void Start()
    {
        CannonCooldownOnStart = CannonCooldown;

    }

    void Update()
    {
        if (CannonCooldown > 0)
        {
            CannonCooldown -= Time.deltaTime;
        }
    }

    void OnFire()
    {
        if (CannonCooldown < 0)
        {
            CannonCooldown = CannonCooldownOnStart;

            GameObject Bellet = Instantiate(SimpleBullet, transform.position + new Vector3(0.5f, 0.0f, 0.0f), transform.rotation);
            Destroy(Bellet, 4f);
        }
        
    }
}
