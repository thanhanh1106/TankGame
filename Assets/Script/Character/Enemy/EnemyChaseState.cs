using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : FSMState<Enemy>
{
    public EnemyChaseState(FSM<Enemy> owner) : base(owner)
    {
    }

    public override void EnterState()
    {
        
    }
    public override void Update()
    {
        subject.characterMove.SetDestination(subject.Player.transform.position);
        if (subject.IsInRangeAttack)
            owner.ChangeState(subject.attackState);
        if(!subject.IsInRangeChase)
            owner.ChangeState(subject.moveState);
    }
    public override void FixUpdate()
    {
        
    }
    public override void LateUpdate()
    {
        
    }

    public override void ExitState()
    {
        subject.characterMove.Agent.isStopped = true;
    }

}
