using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;

    public void Start()
    {
        sentences = new Queue<string>();
    }

    public void DisplayDialogue()
    {

    }

}
