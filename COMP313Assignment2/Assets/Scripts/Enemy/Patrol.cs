using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

    public GameObject[] patrolMarkers;
    //public int numMarkers;

    NavMeshAgent nav;

    // Use this for initialization
    void Awake()
    {
        //patrolMarkers = new GameObject[numMarkers];

        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //nav.SetDestination(player.position);
        if (patrolMarkers.Length > 0)
        {

        }
    }
}
