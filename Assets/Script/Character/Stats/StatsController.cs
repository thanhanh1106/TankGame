using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatsController : MonoBehaviour,IDamageable
{
    [SerializeField] private HealthStats health;
    [SerializeField] private ArmorStats armor;
    [HideInInspector] public UnityEvent OnDie;
    [HideInInspector] public UnityAction OnLowHealth;
    [HideInInspector] public UnityAction OnUnLowHealth;
    private void OnEnable()
    {
        armor.OnBrokenArmor.AddListener(HandlerEndProtection);
        health.OnDie.AddListener(HandlerDie);
    }
    private void OnDisable()
    {
        armor.OnBrokenArmor.RemoveListener(HandlerEndProtection);
        health.OnDie.AddListener(HandlerDie);
    }
    private void Start()
    {
        OnLowHealth = health.OnLowHealth;
        OnUnLowHealth = health.OnUnLowHealth;
    }
    #region Event Handler
    private void HandlerEndProtection(float statsValue)
    {
        health.RemoveStats(statsValue);
    }
    private void HandlerDie()
    {
        OnDie?.Invoke();
    }
    #endregion
    public void TakeDame(float damage)
    {
        armor.RemoveStats(damage);
    }

    public void Healing(float health)
    {
        this.health.AddStats(health);
    }
}
