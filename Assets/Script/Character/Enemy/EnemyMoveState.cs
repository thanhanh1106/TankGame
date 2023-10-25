using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : FSMState<Enemy>
{
    public EnemyMoveState(FSM<Enemy> owner) : base(owner)
    {
    }

    public override void EnterState()
    {
        subject.characterMove.SetDestination(subject.WayPoint[subject.currentPointIndex]);
    }
    public override void Update()
    {

    }

    public override void ExitState()
    {
        
    }

    public override void FixUpdate()
    {
        
    }

    public override void LateUpdate()
    {
        
    }


}
