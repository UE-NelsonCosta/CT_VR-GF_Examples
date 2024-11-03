using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use this file to declare all your states for a given enumeration or statemachine THE ORDER OF THIS HAS TO MATCH THE STATES IN THE ARRAY!
// In a real life situation I'd switch this to use a dictionary.
public enum EPlayerState : int
{
    Invalid = -1,
    Idle = 0,
    MoveForward = 1,
}

public enum EMonsterState
{
    Invalid = -1,
    Idle,
    Patrolling,
    Chasing,
}

