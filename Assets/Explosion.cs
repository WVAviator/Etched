using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo asi, int layerIndex)
    {
        Destroy(animator.gameObject, asi.length);
    }
}
