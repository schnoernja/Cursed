using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script, which handles the enemy movement and the attacking

public class Gaaruzal : Enemy
{
    public Transform target;                // Player
    public float triggerRadius;             // Radius, in which the enemy gets triggered
    public float attackRadius;              // Radius, in which the enemy attacks
    public Vector3 originPosition;          // origin position ofthe enemy
    public float attackSpeed;
    public Vector3 playerLatestPosition;
    //bool isTriggered;
    bool isAttacking;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;

        target = GameObject.FindWithTag("Player").transform;
        originPosition = transform.position;
        //isTriggered = false;
        isAttacking = false;
        XPDrop = 200;
        baseAttack = 4;
    }

    void Update()
    {
            CheckDistanceFromPlayer();
    }

    private void CheckDistanceFromPlayer()
    {

        if (Vector3.Distance(target.position, transform.position) <= triggerRadius && !isAttacking)
        {
            if (Vector3.Distance(target.position, transform.position) > attackRadius)
            {

                //isTriggered = true;
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
            else if (Vector3.Distance(target.position, transform.position) <= attackRadius)
            {

                playerLatestPosition = target.position;

                if(gameObject != null && gameObject.activeInHierarchy) 
                {
                    StartCoroutine(GaaruzalAttackCo());
                }

            }
        }
        else if (Vector3.Distance(target.position, transform.position) >= triggerRadius)
        {

            transform.position = Vector3.MoveTowards(transform.position, originPosition, moveSpeed * Time.deltaTime);
            //isTriggered = false;
        }
    }

    private IEnumerator GaaruzalAttackCo()
    {
        isAttacking = true;

        yield return new WaitForSeconds(0.5f);
        while (Vector3.Distance(transform.position, playerLatestPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerLatestPosition, attackSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        //isTriggered = false;
    }
}
