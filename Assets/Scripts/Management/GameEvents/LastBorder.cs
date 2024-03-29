using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Script which let's the player pass the Mustache Man to go to the boss
public class LastBorder : MonoBehaviour
{
    public string dialogue;
    public GameObject dialogueBox;
    public TMP_Text TMPDialogueText;
    public bool playerInRange;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;

        if (gameManager.canGoToForrestWest == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
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
        if (gameManager.beenyIsFree != true)
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
                    dialogue = "Ich glaube nicht, dass du stark genug bist um weiterzugehen. Das w�re dein Tod! Du konntest ja nicht mal der armen Biene da hinten helfen..";
                    TMPDialogueText.text = dialogue;
                }
            }
        }

        if (gameManager.beenyIsFree == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && playerInRange == true)
            {
                if (dialogueBox.activeInHierarchy)
                {
                    dialogueBox.SetActive(false);
                    gameManager.canGoToForrestWest = true;
                    gameObject.SetActive(false);
                }
                else
                {
                    dialogueBox.SetActive(true);
                    dialogue = "WOW bist du stark! Ich alter Greis h�tte das nie geschafft. Vielleicht bist du ja doch stark genug um... Nein, das w�re zu viel verlangt. Aber abhalten davon werde ich dich sicher nicht!";
                    TMPDialogueText.text = dialogue;
                }
            }
        }

        if (gameManager.gaaruzalIsDead == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && playerInRange == true)
            {
                if (dialogueBox.activeInHierarchy)
                {
                    dialogueBox.SetActive(false);
                    gameManager.canGoToForrestWest = true;
                    gameObject.SetActive(false);
                }
                else
                {
                    dialogueBox.SetActive(true);
                    dialogue = "Ohohoho! Kindchen, du hast also echt den m�chtigen Gaaruzal besiegt? Schade, dass die Demo nun damit endet, du h�ttest bestimmt noch so viel mehr erreichen k�nnen!";
                    TMPDialogueText.text = dialogue;
                }
            }

        }
    }
}
