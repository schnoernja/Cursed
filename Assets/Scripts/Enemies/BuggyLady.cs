using System.Collections;
using UnityEngine;

// Script, which handles the enemy movement and the attacking

public class BuggyLady : Enemy
{
    public Transform target;                // Player
    public float triggerRadius;             // Radius, in whic the enemy gets triggered
    public float attackRadius;              // Radius, in whic the enemy attacks
    public Vector3 originPosition;          // origin position ofthe enemy
    public float attackSpeed;
    public Vector3 playerLatestPosition;  
    //bool isTriggered;
    bool isAttacking;
    

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        originPosition = transform.position;
        //isTriggered = false;
        isAttacking = false;
        XPDrop = 20;
        baseAttack = 2;
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
                if(gameObject != null && gameObject.activeInHierarchy) 
                {
                    playerLatestPosition = target.position;
                    StartCoroutine(buggyLadyAttackCo());
                }
            }
        }
        else if (Vector3.Distance(target.position, transform.position) >= triggerRadius)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, originPosition, moveSpeed * Time.deltaTime);
            //isTriggered = false;
        }
    }

    private IEnumerator buggyLadyAttackCo()
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