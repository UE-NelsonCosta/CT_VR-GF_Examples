using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_PatrollingState : AStateBehaviour
{
    [SerializeField] private POIManager poiManager = null;
    private int lastPOIRequested = 0;

    private NavMeshAgent agent = null;

    public override bool InitializeState()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
            return false;
        return true;
    }

    public override void OnStateEnd()
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateStart()
    {
        if (!poiManager.IsIndexValid(lastPOIRequested))
        {
            lastPOIRequested = 0;
        }

        Transform poiTransform = poiManager.GetPOIAtIndex(lastPOIRequested);
        if (poiTransform)
        {
            agent.SetDestination(poiTransform.position);

            lastPOIRequested++;
        }
    }

    public override void OnStateUpdate()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!poiManager.IsIndexValid(lastPOIRequested))
            {
                lastPOIRequested = 0;
            }

            Transform poiTransform = poiManager.GetPOIAtIndex(lastPOIRequested);
            if (poiTransform)
            {
                agent.SetDestination(poiTransform.position);

                lastPOIRequested++;
            }
        }
    }

    public override int StateTransitionCondition()
    {
//         if (agent.remainingDistance <= agent.stoppingDistance)
//         {
//             return (int)EMonsterState.Idle;
//         }

        return (int)EMonsterState.Invalid;
    }
}
