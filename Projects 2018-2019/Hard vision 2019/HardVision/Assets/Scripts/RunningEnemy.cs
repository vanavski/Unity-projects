using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunningEnemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Player;

    private bool isFollowed = false;
    private float lookRadius = 5f;
    private float distanceToPlayer;

    void Start()
    {
        GetComponent<EnemyController>().canShoot = false;
    }

    void Update()
    {
        if (isFollowed)
        {
            RunAway();
        }

        distanceToPlayer = Vector3.Distance(transform.position, Player.position);
        if (distanceToPlayer < lookRadius)
        {
            isFollowed = true;
        }
    }

    void RunAway()
    {
        isFollowed = false;
        var playerDirection = transform.position - Player.position;
        var newDestination = transform.position + playerDirection;
        Agent.SetDestination(newDestination);
    }
}
