using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyController : MonoBehaviour
{
    // Nav mesh agent
    public NavMeshAgent agent;

    // State machine
    public enum States
    {
        Idle,
        Follow,
        RunAway,
        Patrol
    }

    public States currentState;

    // Follow variables
    public Transform followHandle;
    
    // Run away variables
    public Transform avoidHandle;

    // Patrol variables
    public List<Transform> patrolHandles;
    int patrolIndex;

    // Distance considered "close enough" to be at the patrol point
    public float minimumPatrolDistance = 1; 


    void Start()
    {
        // Set our initial state
        SetState(States.Idle);
    }

    public void SetState(States newState)
    {
        // Update to the new state
        currentState = newState;
    }

    void Update()
    {
        switch (currentState)
        {
            case States.Idle:
                UpdateIdle();
                break;
            case States.Follow:
                UpdateFollow();
                break;
            case States.RunAway:
                UpdateRunAway();
                break;
            case States.Patrol:
                UpdatePatrol();
                break;
        }
    }

    void UpdateIdle()
    {
        // When idle, we don't want to move anymore
        agent.isStopped = true;
    }

    void UpdateFollow()
    {
        // Make sure the agent can move again
        agent.isStopped = false;

        // Find the target position
        var targetPosition = followHandle.position;

        // Set it as the destination
        agent.destination = targetPosition;
    }

    void UpdateRunAway()
    {
        // Make sure we can move
        agent.isStopped = false;

        // Find the position we're trying to avoid
        var avoidPosition = avoidHandle.position;

        // Find the delta between US and the AVOID point
        var ourPosition = transform.position;

        // A vector from A to B = B - A
        // A vector from US to AVOID = AVOID - US
        var usToAvoidDelta = avoidPosition - ourPosition;

        // To run away, flip the vector/delta
        var runToPosition = ourPosition + (usToAvoidDelta * -1);
        agent.destination = runToPosition;
    }

    void UpdatePatrol()
    {
        // Make sure we can move
        agent.isStopped = false;

        // Move towards the current patrol point
        var currentPatrolHandle = patrolHandles[patrolIndex];
        var currentPatrolPosition = currentPatrolHandle.position;

        // If we're "close enough" to the point, move to the next point
        var ourPosition = transform.position;

        // Vector from A to B = B - A
        // The delta from US to the PATROL = PATROL - US
        var usToPatrolDelta = currentPatrolPosition - ourPosition;
        var usToPatrolDistance = usToPatrolDelta.magnitude;
        if (usToPatrolDistance < minimumPatrolDistance)
        {
            // Move to the next patrol point
            patrolIndex += 1;

            // Stay in bounds
            // If we're bigger than the list go back to the start
            if (patrolIndex >= patrolHandles.Count)
            {
                patrolIndex = 0;
            }
        }

        // Finally set our destination
        agent.destination = currentPatrolPosition;
    }
}
