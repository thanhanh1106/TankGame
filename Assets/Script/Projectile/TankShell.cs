using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShell : Projectile
{
    public override PoolMember NameOfMemberPool => PoolMember.TankShell;

    protected override void MoveToDirection(Vector3 direction)
    {
        direction.Normalize();
        rb.AddForce(direction*projectileData.FiringForce, ForceMode.Impulse);   
    }
    protected void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null) damageable.TakeDame(projectileData.Damage);
        Invoke("ReturnPool", 0.2f);
    }
}
