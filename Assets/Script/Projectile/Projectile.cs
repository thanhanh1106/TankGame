using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public ProjectileSO projectileData;
    public abstract PoolMember NameOfMemberPool { get; }
    protected Rigidbody rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    protected virtual void OnEnable()
    {
        Invoke("ReturnPool", projectileData.TimeExistence);
    }
    protected virtual void ReturnPool()
    {
        ObjectPooler.Instance.ReturnGameObjectToPool(NameOfMemberPool, this.gameObject);
    }
    protected abstract void MoveToDirection(Vector3 direction);
}
