using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : FSMState<Enemy>
{
    private float detalTime = 0;
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
        detalTime += Time.deltaTime;

        if (!subject.IsInRangeAttack)
            owner.ChangeState(subject.chaseState);

        if(detalTime >= 1)
        {
            MoveAroundTarget();
            detalTime = 0;
        }

        RotateTower();
        
        subject.Attack();
    }
    private void RotateTower()
    {
        Vector3 diretion = subject.VectorToPlayer.normalized;
        subject.tower.LookAtDirection(diretion);
    }
    private void MoveAroundTarget()
    {
        Vector3 randomDirection = Random.Range(0, 1) <= 0.5 ? subject.tower.transform.right : subject.tower.transform.right * -1;
        subject.characterMove.SetDestination(randomDirection.normalized*20);
    }
}
