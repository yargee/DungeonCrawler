using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseBehaviour : EnemyStateMachine
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Chase();
        CheckDistance();
    }
}
