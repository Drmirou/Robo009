using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnrage : StateMachineBehaviour
{
    public Bosshealth Mother; //nothing ;D

   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Bosshealth>().isInvulnerable = true;
    }

  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
 override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Bosshealth>().isInvulnerable = false;
    }

}

