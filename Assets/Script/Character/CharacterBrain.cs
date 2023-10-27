using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBrain : MonoBehaviour
{
    [SerializeField] protected string id;

     public CharacterMove characterMove;
     public TowerTank tower;
     public CharacterAttack characterAttack;

    public string Id => id;

    protected virtual void Start()
    {
        characterMove = GetComponent<CharacterMove>();
    }
    public virtual void Attack()
    {
        Vector3 direction = tower.transform.forward.normalized;
        characterAttack.Attack(direction);
    }

}
