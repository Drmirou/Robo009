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
        CannonCooldown -= Time.deltaTime;
    }

    void OnFire()
    {
        CannonCooldown = CannonCooldownOnStart;

        GameObject Bellet = Instantiate(SimpleBullet, transform.position, transform.rotation);
        Destroy(Bellet, 4f);
    }
}
