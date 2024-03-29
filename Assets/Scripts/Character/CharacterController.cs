using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the Player control, like walking, attacking, animations, etc

public enum PlayerState
{
    walk,
    attack,
    interact,
    dead
}
public class CharacterController : MonoBehaviour
{
    public PlayerState currentState;
    private Rigidbody2D rigidbody;
    public Animator anim;
    private Vector3 change;
    public float speed = 20.0f;
    public float dashSpeed = 1f;
    public VectorValue spawnPosition;
    

    void Start()
    {
        currentState = PlayerState.walk;
        rigidbody = GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        anim.SetFloat("MoveX", 0f);
        anim.SetFloat("MoveX", -1f);

        transform.position = spawnPosition.initialValue;

    }

    private void Update()
    {
        if (Input.GetButtonDown("Standard_Attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        if (Input.GetButtonDown("Dash") && currentState != PlayerState.attack)
        {
            StartCoroutine(DashCo());
        }
    }
    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(currentState == PlayerState.walk && currentState != PlayerState.attack)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        anim.SetBool("Fighting", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("Fighting", false);
        yield return new WaitForSeconds(0.33f);
        currentState = PlayerState.walk;
    }

    private IEnumerator DashCo()
    {
        speed = speed + dashSpeed;
        yield return new WaitForSeconds(0.2f);
        speed = speed - dashSpeed;
        yield return new WaitForSeconds(1f);
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            anim.SetFloat("MoveX", change.x);
            anim.SetFloat("MoveY", change.y);
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        rigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

}
