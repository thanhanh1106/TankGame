using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : FSMState<Enemy>
{
    private float detalTime;
    public EnemyIdleState(FSM<Enemy> owner) : base(owner)
    {
    }

    public override void EnterState()
    {
        detalTime = 0;
    }
    public override void Update()
    {
        owner.obj.characterMove.Agent.isStopped = true;
        detalTime += Time.deltaTime;
        if (detalTime >= owner.obj.Data.TimeRest)
        {
            owner.obj.currentPointIndex++;
            if (owner.obj.currentPointIndex >= owner.obj.WayPoint.Count)
                owner.obj.currentPointIndex = 0;
            owner.ChangeState(owner.obj.moveState);
        }
            
    }
    public override void FixUpdate()
    {

    }
    public override void LateUpdate()
    {

    }
    public override void ExitState()
    {

    }
}


