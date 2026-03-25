using UnityEngine;

[System.Serializable]
public class Interactable_Dialogue : MonoBehaviour, IInteractable
{
    [SerializeField] public DialogueManager dialogueManager;
    [SerializeField] bool debugEnabled = false;

    public string npcName;
    [Header("Dialogue")]
    [TextArea(3,10)] //box size
    public string[] sentences;

    private void Awake()
    {
        dialogueManager = ServiceHub.Instance.DialogueManager;
    }

    public void Interact()
    {

        if (dialogueManager.inDialogue == true)
        {
            dialogueManager.DisplayNextString();
        }
        else
        {
            dialogueManager.DisplayDialogue(sentences);
        }
        
    }
}
