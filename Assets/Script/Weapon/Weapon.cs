using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponSO WeaponData;
    [SerializeField] protected Transform spawnPoint;
    [HideInInspector] public UnityEvent<bool> OnAttack;
    [HideInInspector] public UnityEvent<int> OnChangeProjectile;

    protected int currentProjectile;
    protected bool isOnReloading;

    protected virtual void Start()
    {
        Reload();
    }


    public abstract void Attack(Vector3 direction);
    public abstract void Reload();
}
