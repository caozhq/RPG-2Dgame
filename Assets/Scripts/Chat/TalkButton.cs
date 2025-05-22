using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject Button;  
    public GameObject talkUI;   

    private bool playerInRange = false;
    private bool isTalking = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  
        {
            playerInRange = true;
            Button.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Button.SetActive(false);   
            talkUI.SetActive(false);   
            isTalking = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.R))
        {
            isTalking = !isTalking;
            talkUI.SetActive(isTalking);
        }
    }
}
