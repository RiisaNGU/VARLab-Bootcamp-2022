using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float jumpHeight = 0;

    private Animator animator;
    private Avatar avatar;

    private Rigidbody rb;
    public GameObject projectile;

    private float movementX;
    private float movementY;
    private bool onGround = true;
    //private bool thrown = true;     // for the snowball item

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
        animator = GetComponentInChildren<Animator>(); // model is a child of the "Player" object
    }

    /// <summary>Detects whether the player is on the ground, or some solid surface
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            onGround = true;
        }

        if(collision.gameObject.tag == "Snowballs")
        {
            //thrown = false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 move= movementValue.Get<Vector2>();

        movementX = move.x;
        movementY = move.y;

        //animator.SetBool("Run", true);
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

    void OnAttack(InputValue click)
    {
        animator.SetBool("LeftClick", true);
        Debug.Log("Attack");
        //thrown = true;

        GameObject clone;
        clone = Instantiate(projectile, transform.position, transform.rotation);
        clone.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 1, 1)*10);

    }

    void OnDefend(InputValue click)
    {
        animator.SetBool("RightClick", true);
        //thrown = true;
    }

    void FixedUpdate()
    {
        /// <summary>Moving the player left and right
        Vector2 movement = new Vector2(movementX, movementY);
        rb.AddForce(movement * speed);


        /// <summary> Reset animations
        animator.SetBool("LeftClick", false);
        animator.SetBool("RightClick", false);
        //animator.SetBool("Run", false);
    }

}
