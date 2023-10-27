using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : FSMState<Enemy>
{
    public EnemyAttackState(FSM<Enemy> owner) : base(owner)
    {
    }

    public override void EnterState()
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

    public override void Update()
    {
        if (!subject.IsInRangeAttack)
            owner.ChangeState(subject.chaseState);
        subject.Attack();
    }
}
