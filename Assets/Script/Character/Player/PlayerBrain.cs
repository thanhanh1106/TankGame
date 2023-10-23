using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : CharacterBrain
{
    private PlayerInputSytem inputSytem;

    private void Awake()
    {
        inputSytem = GetComponent<PlayerInputSytem>();
    }
    private void Update()
    {
        characterMove.LookDirectionAndMove(inputSytem.Movement);
        tower.RotateByInput(inputSytem.RotateTower);
        if (inputSytem.OnAttacking) Attack();
    }
}
