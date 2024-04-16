using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public float slowApproachDistance = 3.0f; // Distance from waypoint to start slowing down
    public float minSpeed = 0.5f; // Minimum speed when approaching waypoint

    private int m_CurrentWaypointIndex;
    private float originalSpeed; // To store the original speed

    void Start ()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        originalSpeed = navMeshAgent.speed; // Store the original speed
    }

    void Update ()
    {
        if(navMeshAgent.remainingDistance < slowApproachDistance)
        {
            // As the agent approaches the waypoint, smoothly decrease its speed
            float speed = Mathf.Lerp(minSpeed, originalSpeed, navMeshAgent.remainingDistance / slowApproachDistance);
            navMeshAgent.speed = speed;
        }
        else
        {
            // Reset speed to original when far enough from the waypoint
            navMeshAgent.speed = originalSpeed;
        }

        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}