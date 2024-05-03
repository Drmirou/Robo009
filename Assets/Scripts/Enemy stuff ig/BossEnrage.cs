using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnrage : MonoBehaviour
{

    public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Bosshealth>().isInvulnerable = true;
    }

 
}

