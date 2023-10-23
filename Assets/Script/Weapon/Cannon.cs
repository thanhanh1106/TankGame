using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Weapon
{
    private bool isFired;
    public override void Attack(Vector3 direction)
    {
        if (currentProjectile == 0 && isFired) return;

        TankShell tankShell = Spawner.TankShellPool.Pull(spawnPoint.position);
        tankShell.MoveInDirection(direction);

        currentProjectile--;
        OnChangeProjectile?.Invoke(currentProjectile);

        isFired = true;
        this.DelayCall(WeaponData.FireRate,() => isFired = false);
    }

    public override void Reload()
    {
        
    }
}
