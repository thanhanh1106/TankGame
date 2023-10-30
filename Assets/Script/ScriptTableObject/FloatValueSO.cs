using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu( menuName = "FloatValue")]
public class FloatValueSO : ScriptableObject
{
    public float MinValue = float.MaxValue;
    public float MaxValue = float.MinValue;

    private float value;

    public UnityEvent<float> OnValueChanged;

    public float Value
    {
        get => value;
        set
        {
           this.value = Mathf.Clamp(value, MinValue, MaxValue);
        }
    }
}
