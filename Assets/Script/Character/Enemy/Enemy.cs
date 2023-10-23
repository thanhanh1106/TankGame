using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBrain
{
    private FSM<Enemy> finiteStateMachine;
    private EnemyMove moveState;
    private void Awake()
    {
        finiteStateMachine = new FSM<Enemy>(this);
        moveState = new EnemyMove(finiteStateMachine);
    }
    protected override void Start()
    {
        finiteStateMachine.Initialized(moveState);
    }

    private void Update()
    {
        finiteStateMachine.CurrentState.Update();
    }
    private void FixedUpdate()
    {
        finiteStateMachine.CurrentState.LateUpdate();
    }
    private void LateUpdate()
    {
        finiteStateMachine.CurrentState.LateUpdate();
    }

}
