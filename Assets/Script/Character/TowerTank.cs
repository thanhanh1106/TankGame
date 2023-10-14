using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTank : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    public void RotateByInput(float inputVetical)
    {
        float rotateAmount = inputVetical * rotateSpeed*Time.deltaTime;
        transform.Rotate(Vector3.up * rotateAmount);
    }
    public void LookAtDirection(Vector3 direction)
    {
        Quaternion targetQuanternion = Quaternion.LookRotation(direction,Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuanternion, rotateSpeed*Time.deltaTime);
    }
}
