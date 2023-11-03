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
    private void OnEnable()
    {
        Invoke("ReturnToPool", projectileData.TimeExistence);
    }
    private void OnDisable()
    {
        CancelInvoke();
        ReturnToPool();
    }

    public override void MoveInDirection(Vector3 direction)
    {
        direction.Normalize();
        //rb.AddForce(direction*projectileData.FiringForce, ForceMode.Impulse);   
        rb.velocity = direction*projectileData.Speed;
    }
    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log("vao day");
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDame(projectileData.Damage);
        }

        gameObject.SetActive(false);
    }
}
