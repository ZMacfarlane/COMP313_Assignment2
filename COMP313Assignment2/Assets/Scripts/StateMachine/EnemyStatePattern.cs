using UnityEngine;
using System.Collections;

public class EnemyStatePattern : MonoBehaviour {

    public Transform[] patrolMarkers;
    public Transform followTarget;
    public Transform goalTarget;

    [HideInInspector]public EnemyState currentState;
    [HideInInspector]public FollowState followState;
    [HideInInspector]public IdleState idleState;
    [HideInInspector]public PatrolState patrolState;
    [HideInInspector]public NavMeshAgent navMeshAgent;
    public Animator anim;



    private void Awake()
    {
        followState = new FollowState(this);
        idleState = new IdleState(this);
        patrolState = new PatrolState(this);
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }
    // Use this for initialization
    void Start () {
        currentState = patrolState;
	}
	
	// Update is called once per frame
	void Update () {
        currentState.UpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }
}
