
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    States state;
    Rigidbody rb;
    bool grounded;
    Collision col;
    // Start is called before the first frame update
    void Start()
    {
        state = States.Idle;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
        PlayerStanding();
    }

    void FixedUpdate()
    {
        grounded = false;
        OnCollisionEnter();
    }


    void DoLogic()
    {
        if (state == States.Idle)
        {
            PlayerStanding();
        }

        if (state == States.Jump)
        {
            PlayerJumping();
        }

        if (state == States.Walk)
        {
            PlayerWalk();
        }
    }


    void PlayerStanding()
    {
        if (Input.GetKeyDown("j") & (grounded == true))
        {
            animator.SetBool("IsJumping", true);
            // simulate jump
            state = States.Jump;
            rb.velocity = new Vector3(0, 10, 0);
        }

        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 0.5f, 0, Space.Self);

        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -0.5f, 0, Space.Self);
        }

        if (Input.GetKey("up"))
        {
            animator.SetBool("IsWalking", false);
            state = States.Walk;
        }
    }

    void PlayerJumping()
    {
        animator.SetBool("IsJumping", true);
        // player is jumping, check for hitting the ground
        if (grounded == true)
        {
            animator.SetBool("IsJumping", false);
            //player has landed on floor
            state = States.Idle;
        }
    }

    void PlayerWalk()
    {
        animator.SetBool("IsWalking", true);
        rb.AddForce(transform.forward * 5f);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 5f);
        if (Input.GetKeyUp("up"))
        {
            animator.SetBool("IsWalking", false);
            state = States.Idle;
        }
    }


    void OnCollisionEnter()
    {
        if (col.gameObject.name == "Floor")
        {
            grounded = true;
            Debug.Log("landed!");
        }
        if (col.gameObject.tag == "Deadly")
        {
            state = States.Dead;
            Debug.Log("dead!");
            Invoke("Revive", 2);
        }
    }

    void Revive()
    {
        state = States.Idle;
        Debug.Log("idle");
    }


}