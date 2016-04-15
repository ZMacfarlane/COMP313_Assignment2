using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed = 6f;
    public float gravity = 3f;
    public float jumpVelocity = 6f;

    Vector3 movement;
    Rigidbody playerRigidBody;
    Animator anim;

    void Awake()
    {
        Cursor.visible = false; //MOVE THIS TO APPROPRIATE SCRIPT
        playerRigidBody = GetComponent<Rigidbody>();
        playerRigidBody.AddForce(Physics.gravity * gravity);
        anim = GetComponent<Animator>();
    }

	void FixedUpdate()
    {
        float forward = Input.GetAxisRaw("Vertical");
        float strafe = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")) Jump();
        Move(forward, strafe);
        Animating(forward, strafe);
        
    }

    void Move(float forward, float right)
    {
        //movement.Set(right, 0f, forward);

        movement = (transform.forward * forward) + (transform.right * right);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidBody.MovePosition(transform.position + movement);
    }

    void Jump()
    {
        if (playerRigidBody.velocity.y <= 0.1 && playerRigidBody.velocity.y >= -0.1)
        {
            playerRigidBody.velocity = new Vector3(0, jumpVelocity, 0);
        }
        
    }

    void Animating(float f, float s)
    {
        bool walking = f != 0f || s != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
