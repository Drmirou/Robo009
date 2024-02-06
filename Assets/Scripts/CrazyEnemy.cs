using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int HP = 0;
    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;

        if (HP < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
