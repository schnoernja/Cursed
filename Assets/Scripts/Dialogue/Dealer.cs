using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dealer : MonoBehaviour
{
    public string dialogue;
    public GameObject dialogueBox;
    public TMP_Text TMPDialogueText;
    public bool playerInRange;

    private void Start()
    {

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
            if (Input.GetKeyDown(KeyCode.F) && playerInRange == true)
            {
                if (dialogueBox.activeInHierarchy)
                {
                    dialogueBox.SetActive(false);
                }
                else
                {
                    dialogueBox.SetActive(true);
                    dialogue = "Jo, Moin und Guten Tag junge Dame!! Ich hab alles was du brauchst! Wobei.. Oh Mist, gerade bin ich komplett ausverkauft. Komm später wieder und wir kommen ins Geschäft! ";
                    TMPDialogueText.text = dialogue;
                }
            }
        }
}
