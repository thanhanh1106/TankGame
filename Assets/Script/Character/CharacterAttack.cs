using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private Weapon weapon;
    private void Start()
    {
        weapon = GetComponentInChildren<Weapon>();
    }

    public void Attack(Vector3 direction)
    {
        weapon.Attack(direction);
    }
}
