using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponData")]
public class WeaponSO : ScriptableObject
{
    [Header("Projectile preflabs")]
    public GameObject Projectile;

    public float FireRate;
    public float ReloadTime;
    public int NumOfProjectile;
}
