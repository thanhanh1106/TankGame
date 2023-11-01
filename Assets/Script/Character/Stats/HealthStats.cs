using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthStats : CharacterStats
{
    [SerializeField]
    [Range(0f,100f)]
    private float ratioLowHealth = 20f;
    [HideInInspector]
    public UnityEvent OnDie;
    [HideInInspector]
    public UnityAction OnLowHealth;
    public UnityAction OnUnLowHealth;

    private float lowHealth;
    protected override void Start()
    {
        base.Start();
        lowHealth = currentStats.MaxValue / 100 * 20;
    }
    public override void AddStats(float statsValue)
    {
        base.AddStats(statsValue);
        if (currentStats.Value > lowHealth)
            OnUnLowHealth?.Invoke();
    }
    public override void RemoveStats(float value)
    {
        base.AddStats(value);
        if (currentStats.Value < lowHealth && currentStats.Value > 0)
            OnLowHealth?.Invoke();
        if (currentStats.Value <= 0)
            Die();
    }
    public void Die()
    {
        currentStats.Value = 0; // chú ý về việc nó gọi event của SO 2 lần
        OnDie?.Invoke();
    }
}

