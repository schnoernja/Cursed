using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Script for after Beeny is freed. Player can now talk to Beeny
public class AfterBeenyIsFree : MonoBehaviour
{
    public string dialogue;
    public GameObject dialogueBox;
    public TMP_Text TMPDialogueText;
    public bool playerInRange;

    private GameManager gameManager;

    public bool bossDefeated;

    private void Start()
    {
        gameManager = GameManager.instance;

        bossDefeated = gameManager.gaaruzalIsDead;

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
        if (gameManager.gaaruzalIsDead != true)
        {
            if (Input.GetKeyDown(KeyCode.F) && playerInRange == true)
            {
                if (dialogueBox.activeInHierarchy)
                {
                    dialogueBox.SetActive(false);

                }
                else
                {
                    dialogueBox.SetActive(true);
                    dialogue = "Uff, danke für deine Hilfe! Ich werde hier aber besser warten, solange der Wald noch nicht wieder sicher ist.. Besonders gefärhlich ist es im Westen zurzeit.. brrr..";
                    TMPDialogueText.text = dialogue;
                }
            }
        }
        else if (gameManager.gaaruzalIsDead == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && playerInRange == true)
            {
                if (dialogueBox.activeInHierarchy)
                {
                    dialogueBox.SetActive(false);

                }
                else
                {
                    dialogueBox.SetActive(true);
                    dialogue = "Du hast was?? Du konntest sogar den bösartigen Gaaruzal bezwingen?? Du bist echt stark! ... Ich hätte da eine Bitte an dich.. Hilfst du mir mein Volk zu rächen?";
                    TMPDialogueText.text = dialogue;
                }
            }

        }

    }
}