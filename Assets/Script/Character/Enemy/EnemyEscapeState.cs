using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyEscapeState : FSMState<Enemy>
{
    public EnemyEscapeState(FSM<Enemy> owner) : base(owner)
    {

    }

    public override void EnterState()
    {
        subject.statsController.OnUnLowHealth = () => owner.ChangeState(subject.chaseState);
    }

    public override void ExitState()
    {
        
    }
    public override void Update()
    {
        subject.statsController.Healing(Time.deltaTime*20); // fix tạm hồi 20 máu 1s
        subject.characterMove.SetDestination(subject.OutwardPlayer.normalized * 20);
        subject.RotateTower();
        subject.Attack();
    }
    public override void FixUpdate()
    {
        
    }

    public override void LateUpdate()
    {
        
    }

    
}
