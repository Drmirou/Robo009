using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float CannonCooldown;
    [SerializeField] float CannonCooldownOnStart;
   
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
    }
}
