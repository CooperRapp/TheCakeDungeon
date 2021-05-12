using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDone : StateMachineBehaviour
{

    public static bool doneAnim = true;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (stateInfo.IsName("Baker_Throw_Top"))
        {

            doneAnim = true;

        }

    }

}
