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
        subject.characterMove.OnArived = () =>  owner.ChangeState(subject.idleState);
        subject.characterMove.SetDestination(subject.WayPoint[subject.currentPointIndex]);
    }
        
    public override void Update()
    {
        if(subject.IsInRangeChase)
            owner.ChangeState(subject.chaseState);
    }

    public override void ExitState()
    {
        subject.characterMove.OnArived = null;
    }

    public override void FixUpdate()
    {
        
    }

    public override void LateUpdate()
    {
        
    }


}
