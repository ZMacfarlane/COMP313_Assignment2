using UnityEngine;
using System.Collections;

public class PatrolState : EnemyState {

    private readonly EnemyStatePattern enemy;
    private int nextWayPoint;

    public PatrolState(EnemyStatePattern enemyStatePattern)
    {
        enemy = enemyStatePattern;
    }

    public void UpdateState()
    {
        Patrol();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            ToFollowState();
    }

    public void OnTriggerExit(Collider other)
    {

    }

    public void ToPatrolState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToFollowState()
    {
        enemy.currentState = enemy.followState;
    }

    public void ToToGoalState()
    {

    }

    public void ToIdleState()
    {

    }

    void Patrol()
    {
        enemy.navMeshAgent.destination = enemy.patrolMarkers[nextWayPoint].position;
        enemy.navMeshAgent.Resume();

        if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending)
        {
            nextWayPoint = (nextWayPoint + 1) % enemy.patrolMarkers.Length;

        }
    }
}
