using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;
    Animator anim;

	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
	
	void Update () {
        nav.SetDestination(player.position);
        Animating();
    }

    void Animating()
    {
        bool walking = nav.velocity.x > 0.05 || nav.velocity.y > 0.05;
        anim.SetBool("IsWalking", walking); 
    }

}
