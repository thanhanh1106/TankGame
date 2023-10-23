using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponSO WeaponData;
    [SerializeField] protected Transform spawnPoint;
    public UnityEvent<bool> OnAttack;
    public UnityEvent<int> OnChangeProjectile;

    protected int currentProjectile;

    protected virtual void Start()
    {
        Reload();
    }


    public abstract void Attack(Vector3 direction);
    public abstract void Reload();
}
