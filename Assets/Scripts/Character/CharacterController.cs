using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    Rigidbody2D rigidbody;

    public Animator anim;

    float horizontal;
    float vertical;
    float speedLimiter = 0.7f;

    public float speed = 20.0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");


        // Animation controller needs to be more compact

        if (horizontal == 0 && vertical == 0)
        {
            anim.SetBool("Standing", true);
        }
        else if (vertical <= -0.01f && horizontal <= -0.01f)
        {
            anim.SetBool("WalkingUp", false);
            anim.SetBool("WalkingDown", true);
            anim.SetBool("Standing", false);
            anim.SetBool("WalkingLeft", false);
            anim.SetBool("WalkingRight", false);
        }
        else if (vertical <= -0.01f && horizontal >= 0.01f)
        {
            anim.SetBool("WalkingUp", false);
            anim.SetBool("WalkingDown", true);
            anim.SetBool("Standing", false);
            anim.SetBool("WalkingLeft", false);
            anim.SetBool("WalkingRight", false);
        }
        else if (vertical >= 0.01f && horizontal >= 0.01f)
        {
            anim.SetBool("WalkingUp", true);
            anim.SetBool("WalkingDown", false);
            anim.SetBool("Standing", false);
            anim.SetBool("WalkingLeft", false);
            anim.SetBool("WalkingRight", false);
        }
        else if (vertical >= 0.01f && horizontal <= -0.01f)
        {
            anim.SetBool("WalkingUp", true);
            anim.SetBool("WalkingDown", false);
            anim.SetBool("Standing", false);
            anim.SetBool("WalkingLeft", false);
            anim.SetBool("WalkingRight", false);
        }
        else if (horizontal >= 0.01f)
        {
            anim.SetBool("WalkingRight", true);
            anim.SetBool("WalkingLeft", false);
            anim.SetBool("Standing", false);
            anim.SetBool("WalkingUp", false);
            anim.SetBool("WalkingDown", false);
        }
        else if (horizontal <= -0.01f)
        {
            anim.SetBool("WalkingLeft", true);
            anim.SetBool("WalkingRight", false);
            anim.SetBool("Standing", false);
            anim.SetBool("WalkingUp", false);
            anim.SetBool("WalkingDown", false);
        }
        else if (vertical >= 0.01f)
        {
            anim.SetBool("WalkingUp", true);
            anim.SetBool("WalkingDown", false);
            anim.SetBool("Standing", false);
            anim.SetBool("WalkingLeft", false);
            anim.SetBool("WalkingRight", false);
        }
        else if (vertical <= -0.01f)
        {
            anim.SetBool("WalkingUp", false);
            anim.SetBool("WalkingDown", true);
            anim.SetBool("Standing", false);
            anim.SetBool("WalkingLeft", false);
            anim.SetBool("WalkingRight", false);
        }
        
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= speedLimiter;
            vertical *= speedLimiter;
        }

        rigidbody.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
