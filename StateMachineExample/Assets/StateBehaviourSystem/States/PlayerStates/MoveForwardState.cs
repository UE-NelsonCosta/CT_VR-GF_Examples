using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class MoveForwardState : AStateBehaviour
{
    private Transform myTransform = null;

    public override bool InitializeState()
    {
        myTransform = GetComponent<Transform>();

        return myTransform;
    }

    public override void OnStateStart() {}

    public override void OnStateUpdate()
    {
        myTransform.position += new Vector3(0, 0, 1) * Time.deltaTime;
    }

    public override void OnStateEnd() {}

    public override int StateTransitionCondition()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return (int)EPlayerState.Idle;
        }

        return (int)EPlayerState.Invalid;
    }
}
