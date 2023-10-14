using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotateSpeed = 10;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform body;

    public Action OnArived;

    public void SetDestination(Vector3 destnation)
    {
        agent.speed = speed;
        agent.isStopped = false;
        agent.SetDestination(destnation);
        if(agent.remainingDistance <= agent.stoppingDistance)
            OnArived?.Invoke();
    }

    public void LookDirectionAndMove(Vector3 diretion)
    {
        if(diretion == Vector3.zero) return;
        diretion.Normalize();
        LookDirection(diretion);
        agent.Move(body.forward.normalized*speed*Time.deltaTime);
    }
    public void Move(Vector3 diretion)
    {
        if (diretion.z == 0) return;

        float rotateAmount = diretion.x*rotateSpeed*Time.deltaTime;
        transform.Rotate(Vector3.up * rotateAmount);
        agent.Move(transform.forward.normalized*diretion.z*speed*Time.deltaTime);
    }

    private void LookDirection(Vector3 diretion)
    {
        Quaternion targetQuanternion = Quaternion.LookRotation(diretion, Vector3.up);
        body.rotation = Quaternion.Lerp(body.rotation, targetQuanternion, Time.deltaTime*rotateSpeed);
    }

}
