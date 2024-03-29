using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// this script is called when the player hits something. It checks whether the hitted object is a destroyable item (like a pumpkin) or an enemy
// it then calls a function of another given script to

public class Hit : MonoBehaviour
{
    public float knockbackForce; // throws the enemy with a given value back after a hit from the player 
    public float knockbackTime;  // time the knockback lasts until the enemy stops again

    public int enemyHealth;

    public int playerBaseAttack;

    private void Start()
    {
        playerBaseAttack = this.GetComponent<PlayerStats>().baseAttack;
        Debug.Log(playerBaseAttack);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destroyable"))
        {
            other.GetComponent<DestroyableObjects>().destroyObject();
        }

        else if (other.CompareTag("Enemy"))
        {

            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            
            //Debug.Log(enemyHealth);

            if (enemy != null)
            {
                    StartCoroutine(KnockBackCo(enemy));
                    other.GetComponent<Enemy>().takeDamage(playerBaseAttack); 
            }

        }
    }

    private IEnumerator KnockBackCo(Rigidbody2D enemy)
    {
        Vector2 forceDirection = enemy.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * knockbackForce;

        enemy.velocity = force;
        yield return new WaitForSeconds(0.3f);

        enemy.velocity = new Vector2();

    }
}
