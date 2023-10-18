using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProjectileData")]
public class ProjectileSO : ScriptableObject
{
    [Header("Config")]
    public float MoveSpeed;
    public float TimeExistence; // thời gian tồn tại
    public float Damage;
    public float FiringForce; // Lực bắn
}
