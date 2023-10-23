using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSytem : MonoBehaviour
{
    public Vector3 Movement {  get; private set; }
    public float RotateTower { get; private set; }
    public bool OnAttacking { get; private set; }
    public event Action OnPressAttackKey;
    public event Action<Vector3> OnPressMovement;


    // started => GetKeyDown
    // performed => GetKey
    // canceled => GetKeyUp
    #region Call By InputSytem
    public void OnMove(InputAction.CallbackContext value)
    {
        MoveInput(value.ReadValue<Vector2>());
    }
    public void OnAttack(InputAction.CallbackContext value)
    {
        AttackInput(value.performed);
    }
    public void OnRotateTower(InputAction.CallbackContext value)
    {
        RotateTowerInput(value.ReadValue<float>());
    }
    #endregion

    public void MoveInput(Vector2 value)
    {
        Movement = new Vector3(value.x,0,value.y);
        if (value != Vector2.zero)
            OnPressMovement?.Invoke(Movement);
    }
    public void AttackInput(bool value)
    {
        OnAttacking = value;
        if (value) OnPressAttackKey?.Invoke();
    }
    public void RotateTowerInput(float value)
    {
        RotateTower = value;
        
    }
}
