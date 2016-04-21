using UnityEngine;
using System.Collections;

public class FollowState : EnemyState {

    private readonly EnemyStatePattern enemy;

    public FollowState(EnemyStatePattern enemyStatePattern)
    {
        enemy = enemyStatePattern;
    }

    public void UpdateState()
    {
        Follow();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Goal");
            ToIdleState();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ToPatrolState();
        }
    }

    public void ToPatrolState()
    {
        enemy.currentState = enemy.patrolState;
    }

    public void ToFollowState()
    {
        
    }

    public void ToToGoalState()
    {

    }

    public void ToIdleState()
    {
        enemy.currentState = enemy.idleState;
    }

    void Follow()
    {
        enemy.navMeshAgent.destination = enemy.followTarget.position;
        enemy.navMeshAgent.Resume();
    }

}
