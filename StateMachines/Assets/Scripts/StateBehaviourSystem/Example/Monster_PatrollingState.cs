using UnityEngine;
using UnityEngine.AI;

public class Monster_PatrollingState : AStateBehaviour
{
    [SerializeField] private POIManager poiManager = null;
    private int lastPOIRequested = 0;

    private NavMeshAgent agent = null;
    private LineOfSight monsterLineOfSight = null;
    
    // Example of getting all the relevant components
    public override bool InitializeState()
    {
        agent = GetComponent<NavMeshAgent>();
        monsterLineOfSight = GetComponent<LineOfSight>();

        if (agent == null || monsterLineOfSight == null)
            return false;
        return true;
    }

    // Rquest a POI and move on from there, setup the agent
    public override void OnStateStart()
    {
        if (!poiManager.IsIndexValid(lastPOIRequested))
        {
            lastPOIRequested = 0;
        }

        Transform poiTransform = poiManager.GetPOIAtIndex(lastPOIRequested);
        if (poiTransform)
        {
            agent.isStopped = false;
            agent.SetDestination(poiTransform.position);

            lastPOIRequested++;
        }
    }

    // Keep agent moving between points unless interupted in the StateTransitionCondition
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
                agent.isStopped = false;
                agent.SetDestination(poiTransform.position);

                lastPOIRequested++;
            }
        }
    }
    // Cleanup of the state, as we should always turn off any variables we turn on in start, next state can turn them back on if it see's fit to do so
    public override void OnStateEnd()
    {
        agent.isStopped = true;
    }

    // Transition out of this state if we see the player.
    public override int StateTransitionCondition()
    {
        if (monsterLineOfSight.HasSeenPlayerThisFrame())
        {
            return (int)EMonsterState.Chasing;
        }

        return (int)EMonsterState.Invalid;
    }
}
