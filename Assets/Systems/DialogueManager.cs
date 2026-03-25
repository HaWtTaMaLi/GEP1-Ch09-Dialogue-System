using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private PlayerMovementController playerMovement;
    [SerializeField] private PlayerInteractionController playerInteraction;

    public Queue<string> dialogueQueue;

    [SerializeField] bool debugEnabled = false;

    public bool inDialogue = false;

    public void Awake()
    {
        uiManager = ServiceHub.Instance.UIManager;
        playerInteraction = ServiceHub.Instance.Player.GetComponent<PlayerInteractionController>();
        playerMovement = ServiceHub.Instance.Player.GetComponent<PlayerMovementController>();

        dialogueQueue = new Queue<string>();
    }

    public void DisplayDialogue(string[] sentences)
    {

        uiManager.ShowDialoguePanel();
        inDialogue = true;
        playerMovement.moveEnabled = false;
        //playerInteraction.

        Debug.Log($"Interacted with Dialogue Manager");

        //tell the us manager to displau the dialogue panel
        foreach(string currentString in sentences)
        {
            dialogueQueue.Enqueue(currentString);
        }

        DisplayNextString();

        Debug.Log($"Dialogue Manager: Interacted");

        // queue.Clear()    Removes all objects from the Queue<T>.
        // queue.Dequeue()  Removes and returns the object at the beginning of the Queue<T>.
        // queue.Enqueue(T) Adds an object to the end of the Queue<T>.
        // queue.Peek()     Returns the object at the beginning of the Queue<T> without removing it.
    }

    public void DisplayNextString()
    {


        if(dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        else if(dialogueQueue.Count > 0)
        {
            Debug.Log(dialogueQueue.Count);
            uiManager.SetDialogueText(dialogueQueue.Dequeue());
        }
    }

    private void EndDialogue()
    {
        dialogueQueue.Clear();
        uiManager.HideDialoguePanel();

        inDialogue = false;
        playerMovement.moveEnabled = true;
    }
}
