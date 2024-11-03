using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This has to be abstract due to having a base class for states.
// Unity does not serialize anything related to interfaces
// abstract on class declaration just means it cannot be instantiated using the new keyword
// abstract on function declarations just means that the body isn't declared here, but instead in the children
// See any of the Monster_XXX states
public abstract class AStateBehaviour : MonoBehaviour
{
    public StateMachine AssociatedStateMachine { get; set; }
    public abstract bool InitializeState();
    public abstract void OnStateStart();
    public abstract void OnStateUpdate();
    public abstract void OnStateEnd();
    public abstract int StateTransitionCondition();
}
