﻿using UnityEngine;
using System.Collections;

public class GuardScript : MonoBehaviour {

     

    [SerializeField] float      speed = 1.0f;
    [SerializeField] float      jumpForce = 4.0f;

    private float               inputX;
    private Animator            animator;
    private Rigidbody2D         body2d;
    private bool                combatIdle = false;
    private bool                isGrounded = true;
    int jumpCount = 0;
    int IdleTimer;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        body2d = GetComponent<Rigidbody2D>();
        IdleTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        combatIdle = false;
        IdleTimer++;
        // -- Handle input and movement --
        inputX = Input.GetAxis("Horizontal");


        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            IdleTimer = 0;
        }
        else if (inputX < 0)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            IdleTimer = 0;
        }
        // Move
        body2d.velocity = new Vector2(inputX * speed, body2d.velocity.y);

        // -- Handle Animations --
        isGrounded = IsGrounded();
        animator.SetBool("Grounded", isGrounded);

        //Death
        if (Input.GetKeyDown("k"))
            animator.SetTrigger("Death");
        //Hurt
        else if (Input.GetKeyDown("h"))
        {
            animator.SetTrigger("Hurt");
        }
        //Recover
        else if (Input.GetKeyDown("r"))
            animator.SetTrigger("Recover");
        //Change between idle and combat idle
        else if (Input.GetKeyDown("i"))
            combatIdle = !combatIdle;



        //Attack
        else if (Input.GetKeyDown("q"))
        {
            animator.SetTrigger("Attack");
            GetComponent<AudioSource>().Play();
            IdleTimer = 0;
        }

        //Jump
        else if (Input.GetKeyDown("w") && isGrounded)
        {
            jumpCount = 0;
            animator.SetTrigger("Jump");
            body2d.velocity = new Vector2(body2d.velocity.x, jumpForce);
            IdleTimer = 0;

        }

         else if (jumpCount < 1 && Input.GetKeyDown("w"))
        {
            
            animator.SetTrigger("Jump");
            body2d.velocity = new Vector2(body2d.velocity.x, jumpForce);
            jumpCount++;
            IdleTimer = 0;
        }

        //Walk
        else if (Mathf.Abs(inputX) > Mathf.Epsilon && isGrounded)
            animator.SetInteger("AnimState", 2);
        //Combat idle
        else if (combatIdle)
            animator.SetInteger("AnimState", 1);
        //Idle
        else
            animator.SetInteger("AnimState", 0);
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector3.up, 0.03f);
    }

    
}
