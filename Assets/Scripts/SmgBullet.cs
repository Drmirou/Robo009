using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmgBullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    Rigidbody2D myRigidbody;
    public float force;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        myRigidbody = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        myRigidbody.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // DO stuff if hits enemy

        }

        Destroy(gameObject);
    }
}
