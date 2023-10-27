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

    private bool isMoveWithDestination;
    private Vector3 currentDestination;

    public NavMeshAgent Agent => agent;

    private void Update()
    {
        if (isMoveWithDestination && Arived(currentDestination))
        {
            OnArived?.Invoke();
            isMoveWithDestination = false;
        }
            
    }

    public void SetDestination(Vector3 destnation)
    {
        agent.speed = speed;
        agent.isStopped = false;
        isMoveWithDestination = true;
        currentDestination = destnation;
        agent.SetDestination(destnation);
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
    private bool Arived(Vector3 destination)
    {
        return Vector3.Distance(transform.position, destination) <= 0.2;
    }

}
