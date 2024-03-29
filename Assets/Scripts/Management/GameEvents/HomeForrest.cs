using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Script for the "game event": "TalkedToMustacheMen", so that the player can go to "Horolon East"
public class HomeForrest : MonoBehaviour
{
    public string dialogue;
    public GameObject dialogueBox;
    public TMP_Text TMPDialogueText;
    public bool playerInRange;

    public bool eventFinished;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;

        eventFinished = gameManager.talkedToMustacheMan;
        gameObject.SetActive(false);
        if(eventFinished == false)
        {
            gameObject.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("In Range");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueBox.SetActive(false);
        }
    }

    private void Update()
    {
        if(eventFinished != true) 
        {
            if (Input.GetKeyDown(KeyCode.F) && playerInRange == true)
            {
                if (dialogueBox.activeInHierarchy)
                {
                    dialogueBox.SetActive(false);
                    eventFinished = true;
                    gameManager.talkedToMustacheMan = eventFinished;

                }
                else
                {
                    dialogueBox.SetActive(true);
                    TMPDialogueText.text = dialogue;
                }
            }
        } else 
            { 
                gameObject.SetActive(false); 
                
            }

    }
}
