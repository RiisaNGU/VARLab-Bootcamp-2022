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
    private float movementZ;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementZ = movementVector.y;
    }

    void OnJump(InputValue jump)
    {
        Vector3 j = jump.Get<Vector3>();

        movementY = j.z;

        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    void FixedUpdate()
    {
        // moving left and right
        Vector3 movement = new Vector3(movementX, 0.0f, movementZ);
        rb.AddForce(movement * speed);
    }

    void Update()
    {

    }
}
