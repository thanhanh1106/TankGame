using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBrain : MonoBehaviour
{
    [SerializeField] protected string id;

    public CharacterMove characterMove;
    public TowerTank tower;
    public CharacterAttack characterAttack;
    public StatsController statsController;

    public string Id => id;

    protected virtual void OnEnable()
    {
        statsController.OnDie.AddListener(HandlerDie);
    }
    protected virtual void OnDisable()
    {
        statsController.OnDie.RemoveListener(HandlerDie);
    }

    protected virtual void Start()
    {
        characterMove = GetComponent<CharacterMove>();
        characterAttack = GetComponent<CharacterAttack>();
    }
    public virtual void Attack()
    {
        Vector3 direction = tower.Weapon.transform.forward.normalized;
        characterAttack.Attack(direction);
    }

    protected virtual void HandlerDie()
    {
        
    }


}
