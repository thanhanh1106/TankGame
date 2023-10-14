using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState<T> where T : MonoBehaviour
{
    protected FSM<T> owner;

    public FSMState(FSM<T> owner)
    {
        this.owner = owner;
    }

    public abstract void EnterState();
    public abstract void Update();
    public abstract void FixUpdate();
    public abstract void LateUpdate();
    public abstract void ExitState();
}
