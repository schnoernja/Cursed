using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Script for the enemy basics, like (basic) movement and stats etc
// Handles also the damage the enemy takes from the player

public class Enemy : MonoBehaviour
{
    public int enemyLife = 5;
    public int baseAttack;
    public int XPDrop = 100; // should be changed for specific enemy types; but will work for now
    public int moveSpeed;
    public bool gaaruzalDead;

    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.instance;
       // gaaruzalDead = gameManager.gaaruzalIsDead;
    }
    public void takeDamage(int amountOfDamage)
    {
        enemyLife = enemyLife - amountOfDamage;
        Debug.Log(enemyLife);


        if(enemyLife <= 0)
        {
            XPManager.instance.AddExperience(XPDrop);
            gameObject.SetActive(false);
        } 
        if(gameObject != null && gameObject.activeInHierarchy) 
        { 
            StartCoroutine(damageCooldown()); 
        }
        
    }
   
    private IEnumerator damageCooldown()
    {
        yield return new WaitForSeconds(2f);
    }
}
