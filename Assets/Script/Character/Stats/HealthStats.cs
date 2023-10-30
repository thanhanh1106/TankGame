using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthStats : CharacterStats
{
    public UnityEvent OnDie;
    public override void AddStats(float statsValue)
    {
        base.AddStats(statsValue);
    }
    public override void RemoveStats(float statsValue)
    {
        base.AddStats(statsValue);
        if (currentStats.Value <= 0)
            Die();
    }
    public void Die()
    {
        currentStats.Value = 0; // chú ý về việc nó gọi event của SO 2 lần
        OnDie?.Invoke();
    }
}

