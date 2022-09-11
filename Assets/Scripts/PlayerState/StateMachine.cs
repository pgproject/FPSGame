using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State CurremtState { get; private set; }

    public void Initialize(State startState)
    {
        CurremtState = startState;
        startState.Enter();
    }

    public void ChangeState(State newState)
    {
        CurremtState.Exit();

        CurremtState = newState;
        CurremtState.Enter();
    }
}
