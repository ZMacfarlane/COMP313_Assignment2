using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed = 6f;
    public float gravity = 3f;
    public float jumpVelocity = 6f;
    public float defaultSpeed = 6f;
    public float sprintSpeed = 24f;

    Vector3 movement;
    Rigidbody playerRigidBody;
    Animator anim;
    Collider playerCollider;
    float distanceToGround;

    void Awake()
    {
        Cursor.visible = false; //MOVE THIS TO APPROPRIATE SCRIPT
        playerRigidBody = GetComponent<Rigidbody>();
        playerRigidBody.AddForce(Physics.gravity * gravity);
        anim = GetComponent<Animator>();
        playerCollider = GetComponent<Collider>();
        distanceToGround = playerCollider.bounds.extents.y;
    }

	void FixedUpdate()
    {
        float forward = Input.GetAxisRaw("Vertical");
        float strafe = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            //playerRigidBody.velocity.y += jumpVelocity;
            //Jump();
        }
        if (Input.GetKey("left shift"))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = defaultSpeed;
        }
        /*
        if (Input.GetKeyUp("left shift"))
        {
            speed = defaultSpeed;
        }
        */
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
        //if (playerRigidBody.velocity.y <= 0.1 && playerRigidBody.velocity.y >= -0.1)
        
        //{
            playerRigidBody.velocity = new Vector3(0, jumpVelocity, 0);
        //}
        
    }

    void Animating(float f, float s)
    {
        bool walking = f != 0f || s != 0f;
        anim.SetBool("IsWalking", walking);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.4f);
    }
}
