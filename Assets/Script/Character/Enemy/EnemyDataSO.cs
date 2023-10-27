using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data")]
public class EnemyDataSO : ScriptableObject
{
    public float TimeRest;
    public float RangeChase = 20;
    public float RangeAttack = 10;
}
