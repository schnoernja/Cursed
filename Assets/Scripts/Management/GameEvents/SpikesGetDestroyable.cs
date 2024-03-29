using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for the "game event": "CanDestroyCage", so that the player can free Beeny

public class SpikesGetDestroyable : MonoBehaviour
{

    private GameManager gameManager;

    public bool spikesCanBeDestroyed;
    public bool beenyIsFreed;

    void Start()
    {
        gameManager = GameManager.instance;

        spikesCanBeDestroyed = gameManager.canDestroyCage;
        beenyIsFreed = gameManager.beenyIsFree;

        if(beenyIsFreed == true)
        {
           gameObject.SetActive(false);
        } else 
        { 
           gameObject.SetActive(true); 
        }

    }

    void Update()
    {
        if(gameManager.beenyIsFree == true) 
        {
            Debug.Log("beey is freed");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameManager.canDestroyCage == true )
        {
            gameManager.beenyIsFree = true;
            gameObject.SetActive(false);
        }
    }
}
