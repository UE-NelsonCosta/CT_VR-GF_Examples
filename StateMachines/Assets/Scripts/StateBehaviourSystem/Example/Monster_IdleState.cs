using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Monster Idle state, uses the AStateBehaviour as a base
public class Monster_IdleState : AStateBehaviour
{
    [SerializeField] private float maxTimer = 1.0f;
    float currentTimer = 0.0f;

    // No Initialization To Do 
    public override bool InitializeState()
    {
        return true;
    }

    // Just Making Sure Everytime We Come Into The State We Reset The Timer
    public override void OnStateStart()
    {
        currentTimer = maxTimer;
    }

    // Update The State (Runs in Update timeline)
    public override void OnStateUpdate()
    {
        currentTimer -= Time.deltaTime;
    }

    // Nothing to cleanup, but we can add cleanup code here
    public override void OnStateEnd()
    {
    }

    // This returns the specific state to transition to, assuming a condition has been met
    public override int StateTransitionCondition()
    {
        if (currentTimer <= 0.0f)
        {
            return (int)EMonsterState.Patrolling;
        }

        return (int)EMonsterState.Invalid;
    }
}
