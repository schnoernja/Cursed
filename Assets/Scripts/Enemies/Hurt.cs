using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script holds the power to hurt the player!
public class Hurt : MonoBehaviour
{
    public float knockbackForce; // throws the player with a given value back after a hit from the enemy 
    public float knockbackTime;  // time the knockback lasts until the player stops again

    //public int playerHealth;

    public int enemyBaseAttack;

    private void Start()
    {
        enemyBaseAttack = this.GetComponent<Enemy>().baseAttack;
        Debug.Log(enemyBaseAttack);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if (other.CompareTag("Player"))
        {
            Rigidbody2D player = other.GetComponent<Rigidbody2D>();

            if (player != null)
            {
                StartCoroutine(KnockBackCo(player));                          // needs to be fixed. In it's current state, the Player sometimes flies across the whole map when hit by an enemy
                StartCoroutine(CoolDownCo());
                other.GetComponent<PlayerStats>().takeDamage(enemyBaseAttack); 
            }
        }
    }

    private IEnumerator KnockBackCo(Rigidbody2D player)
    {
        Vector2 forceDirection = player.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * knockbackForce;

        player.velocity = force;
        yield return new WaitForSeconds(0.3f);

        player.velocity = new Vector2();

    }

    private IEnumerator CoolDownCo()
    {
        yield return new WaitForSeconds(2f);
    }
}
