using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : CharacterBrain
{
    #region FSM
    private FSM<Enemy> finiteStateMachine;
    public EnemyIdleState idleState;
    public EnemyMoveState moveState;
    public EnemyChaseState chaseState;
    public EnemyAttackState attackState;
    public EnemyEscapeState escapeState;
    #endregion

    [SerializeField] EnemyDataSO EnemyData;

    [HideInInspector] public List<Vector3> WayPoint;
    [HideInInspector] public int currentPointIndex;

    #region Reference
    private GameManager manager => GameManager.Instance;
    public PlayerBrain Player => manager.Player;
    #endregion

    public Vector3 VectorToPlayer => Player.transform.position - transform.position;
    public Vector3 OutwardPlayer => transform.position - Player.transform.position;
    public bool IsInRangeChase => VectorToPlayer.sqrMagnitude <= EnemyData.RangeChase * EnemyData.RangeChase;
    public bool IsInRangeAttack => VectorToPlayer.sqrMagnitude <= EnemyData.RangeAttack*EnemyData.RangeAttack;

    #region Property
    public EnemyDataSO Data => EnemyData;
    #endregion

    private void Awake()
    {
        InitFSM();
        InitWaypoint();
    }
    private void InitWaypoint()
    {
        WayPoint = manager.EnemyWayPoint.
            SingleOrDefault(wayPoint => wayPoint.TargetEnemyId.
            Equals(id))?.listPoints.Select(point => point.position).
            ToList();
    }
    private void InitFSM()
    {
        finiteStateMachine = new FSM<Enemy>(this);
        idleState = new EnemyIdleState(finiteStateMachine);
        moveState = new EnemyMoveState(finiteStateMachine);
        chaseState = new EnemyChaseState(finiteStateMachine);
        attackState = new EnemyAttackState(finiteStateMachine);
        escapeState = new EnemyEscapeState(finiteStateMachine);
    }
    protected override void Start()
    {
        finiteStateMachine.Initialized(idleState);
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

    public void RotateTower()
    {
        Vector3 direction = VectorToPlayer.normalized;
        tower.LookAtDirection(direction);
    }

}
