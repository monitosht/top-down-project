using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState CurrentState {get; private set;}

    public void Initilaize(PlayerState startState)
    {
        CurrentState = startState;
        CurrentState.Enter();       
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
        //Debug.Log("entered "+newState+" state");
    }
}
