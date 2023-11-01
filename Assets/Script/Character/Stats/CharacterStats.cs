using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] 
    protected FloatValueSO currentStats;

    [HideInInspector]
    public UnityEvent<float> OnStatsChanged;
    [HideInInspector]
    public UnityEvent<float> OnStatsAdd;
    [HideInInspector]
    public UnityEvent<float> OnStatsRemove;

    protected virtual void Start()
    {
        currentStats.Value = currentStats.MaxValue;
    }

    public virtual void AddStats(float statsValue)
    {
        float currentStats = this.currentStats.Value;
        currentStats += statsValue;
        this.currentStats.Value = currentStats;
        OnStatsChanged?.Invoke(currentStats);
        OnStatsAdd?.Invoke(statsValue);
    }
    public virtual void RemoveStats(float statsValue)
    {
        float currentStats = this.currentStats.Value;
        currentStats -= statsValue;
        this.currentStats.Value = currentStats;
        OnStatsChanged?.Invoke(currentStats);

        OnStatsRemove?.Invoke(statsValue);
    }
    public virtual void ResetStats()
    {
        currentStats.Value = currentStats.MaxValue;
    }
}
