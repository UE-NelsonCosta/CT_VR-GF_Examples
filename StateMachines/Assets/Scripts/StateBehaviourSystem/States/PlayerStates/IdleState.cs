using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AStateBehaviour
{
    // Initialize Components Etc in Here
    public override bool InitializeState()
    {
        return true;
    }

    public override void OnStateStart()
    {
    }

    public override void OnStateUpdate()
    {
    }

    public override void OnStateEnd()
    {
    }

    public override int StateTransitionCondition()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return (int)EPlayerState.MoveForward;
        }

        return (int)EPlayerState.Invalid;
    }


}
