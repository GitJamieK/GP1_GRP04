using System;
using System.Collections.Generic;
using UnityEngine;
using Jesper.GeneralStateMachine;

public class StateMachine : MonoBehaviour
{
    public List<ManagerStates> states;
    protected ManagerStates currentState;
    
    protected virtual void AddStates(){}

    public void UpdateStateMachine()
    {
        currentState?.LogicUpdate();
    }

    protected void SwitchState<TanyState>()
    {
        foreach (ManagerStates state in states)
        {
            if (state.GetType() == typeof(TanyState))
            {
                currentState?.OnExit();
                currentState = state;
                currentState?.OnEnter();
                return;
            }
        }
        Debug.LogError("State does not match type");
    }
}