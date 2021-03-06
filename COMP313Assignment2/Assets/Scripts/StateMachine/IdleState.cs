﻿using UnityEngine;
using System.Collections;

public class IdleState : EnemyState {

    private readonly EnemyStatePattern enemy;

    public IdleState(EnemyStatePattern enemyStatePattern)
    {
        enemy = enemyStatePattern;
    }

    public void UpdateState()
    {
        enemy.anim.SetBool("IsWalking", false);
        Idle();
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        
    }

    public void ToPatrolState()
    {

    }

    public void ToFollowState()
    {

    }

    public void ToToGoalState()
    {

    }

    public void ToIdleState()
    {

    }

    void Idle()
    {

    }
}
