using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float jumpHeight = 0;

    private InputAction action;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool onGround = true;

    ///<summary>Current state of the player
    /// For a "Paper Mario" style implementation
    /// Switches camera/game modes
    [System.Flags]
    enum States
    {
        twoDMode,
        threeDMode
    }
    private States state = States.twoDMode; // 2D is default


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        action = new InputAction();
    }

    /// <summary>Detects whether the player is on the ground, or some solid surface
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
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
        /// <summary> jumping using [space]
        float j = jump.Get<float>();

        if (onGround == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            onGround = false;
        }
    }

    void FixedUpdate()
    {
        /// <summary>Moving the player left and right
        Vector2 movement = new Vector2(movementX, movementY);
        rb.AddForce(movement * speed);
    }

    private void Update()
    {
        
    }
}
