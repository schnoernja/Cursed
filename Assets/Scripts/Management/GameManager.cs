using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { private set; get; }

    public float playerLife;
    public float maxLife = 10f;
    public int basePlayerAttack = 1;

    public int currentXp = 10;
    public int maxXp = 120;
    public int currentLevel = 1;

    public bool talkedToMustacheMan = false;        // moves mustache man away from entry to horolon east
    public bool canDestroyCage = false;             // player can destroy beenys cage and spikes in front of the well (well needs yet to get interactive)
    public bool beenyIsFree = false;                // player has freed beeny
    public bool canGoToForrestWest = false;         // player can go to Horolon Forrest West
    public bool gaaruzalIsDead = true;


    PlayerStats playerStats;
    HomeForrest homeForrest;
    SpikesGetDestroyable spikesGetDestroyable;
    XPManager xpManager;
    Enemy enemy;



    private void Awake()
    {
       if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
       else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if(playerStats != null)
        {
            playerStats.playerHealth = playerLife;
            playerStats.currentXp = currentXp;
            playerStats.currentLevel = currentLevel;
            if (playerStats.reachedLevelTwo == true)
            {
                playerStats.reachedLevelTwo = canDestroyCage;
            }
        }

        if(homeForrest != null)
        {
            homeForrest.eventFinished = talkedToMustacheMan;
        }

        if(spikesGetDestroyable != null) 
        {
            spikesGetDestroyable.beenyIsFreed = beenyIsFree;
        }

        if(enemy != null)
        {

            enemy.gaaruzalDead = gaaruzalIsDead;
        }
    }
}
