using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy2 : MonoBehaviour

{

    public float minSpeed = 5f;
    public float maxSpeed = 10f;
    public float changeInterval = 2f; // Interval to change direction
    

    private Vector2 direction;
    private float speed;

    private float timer;
    public float HP;
    void Start()
    {
        // Set initial speed and direction
        speed = Random.Range(minSpeed, maxSpeed);
        direction = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // Move the enemy
        transform.Translate(direction * speed * Time.deltaTime);

        // Update the timer
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // Change direction
            direction = Random.insideUnitCircle.normalized;
            timer = changeInterval;
        }
    }
    public void Takedamage(int aHPValue)
    {
        HP += aHPValue;

        if (HP < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
        
}

// FREEDOM RAHHHH :BIRD: :BRID: