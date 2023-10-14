using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBrain : MonoBehaviour
{
    [SerializeField] protected string id;

    [SerializeField] protected CharacterMove characterMove;
    [SerializeField] protected TowerTank tower;
    public string Id => id;

    protected virtual void Start()
    {
        characterMove = GetComponent<CharacterMove>();
    }

}
