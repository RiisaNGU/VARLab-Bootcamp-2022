using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float jumpHeight = 0;

    private InputAction action;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool onGround = true;

    ///<summary>Current state of the player
    [System.Flags]
    enum States
    {
        Moving = 1,
        Jumping = 1,
        Falling = 1,
        OnGround = 1
    }
    private States state;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        action = new InputAction();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 move= movementValue.Get<Vector2>();

        movementX = move.x;
        movementY = move.y;
    }

    void OnJump(InputValue jump)
    {
        /// <summary> jumping using [space], currently infinite jumping???
        float j = jump.Get<float>();

        if (onGround == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            onGround = false;
        }
    }

    void FixedUpdate()
    {
        /// <summary>moving left and right
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void Update()
    {
        
    }
}
