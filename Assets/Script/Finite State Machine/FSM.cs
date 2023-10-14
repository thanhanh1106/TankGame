using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T> where T : MonoBehaviour
{
    public T obj;
    public FSMState<T> CurrentState { get; set; }

    public FSM(T obj)
    {
        this.obj = obj;
    }

    public void Initialized(FSMState<T> state)
    {
        CurrentState = state;
        CurrentState.EnterState();
    }
    public void ChangeState(FSMState<T> state)
    {
        CurrentState.ExitState();
        CurrentState = state;
        CurrentState.EnterState();
    }
}
