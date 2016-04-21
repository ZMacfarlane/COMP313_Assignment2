using UnityEngine;
using System.Collections;

public interface EnemyState {

    void UpdateState();

    void OnTriggerEnter(Collider other);

    void OnTriggerExit(Collider other);

    void ToPatrolState();

    void ToFollowState();

    void ToToGoalState();

    void ToIdleState();
}
