using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyObjectPooling;
using System;

public class TankShell : Projectile,IPoolable<TankShell>
{
    private Action<TankShell> returnAction;
    public void Initialize(Action<TankShell> returnAction)
    {
        this.returnAction = returnAction;
    }

    public void ReturnToPool()
    {
        returnAction?.Invoke(this);
    }
    private void OnDisable()
    {
        ReturnToPool();
    }

    public override void MoveInDirection(Vector3 direction)
    {
        direction.Normalize();
        rb.AddForce(direction*projectileData.FiringForce, ForceMode.Impulse);   
    }
    protected void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null) damageable.TakeDame(projectileData.Damage);

        gameObject.SetActive(false);
    }
}