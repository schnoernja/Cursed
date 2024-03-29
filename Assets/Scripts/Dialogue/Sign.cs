using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Script for signs, so that they display text when interacted with
public class Sign : MonoBehaviour
{
    public string dialogue;
    public GameObject dialogueBox;
    public TMP_Text TMPDialogueText;
    public bool playerInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
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
        if(Input.GetKeyDown(KeyCode.F) && playerInRange == true)
        {
            if(dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            } else
            {
                dialogueBox.SetActive(true);
                TMPDialogueText.text = dialogue;
            }
        }
    }
}
