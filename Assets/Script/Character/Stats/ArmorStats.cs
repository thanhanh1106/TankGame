using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArmorStats : CharacterStats
{
    [SerializeField] private float damageReductionRate = 50f;

    [HideInInspector]
    public UnityEvent<float> OnBrokenArmor;
    public override void AddStats(float statsValue)
    {
        base.AddStats(statsValue);
    }

    public override void RemoveStats(float statsValue)
    {
        float numOfRemainDamage = statsValue * (100 - damageReductionRate) / 100;
        if (currentStats.Value >= numOfRemainDamage)
            base.RemoveStats(numOfRemainDamage);
        else if (currentStats.Value < numOfRemainDamage && currentStats.Value > 0)
        {
            // nếu số dame đã giảm vẫn lớn hơn số giáp còn lại thì trừ hết số giáp còn lại đi
            // còn bao nhiêu dame trừ thẳng vào máu
            float damage = (numOfRemainDamage - currentStats.Value) / (100 - damageReductionRate) * 100;
            base.RemoveStats(currentStats.Value);
            BrokenArmor(damage);
        }
        else
        {
            BrokenArmor(statsValue);
        }
    }
    public void BrokenArmor(float value)
    {
        OnBrokenArmor.Invoke(value);
    }


}
