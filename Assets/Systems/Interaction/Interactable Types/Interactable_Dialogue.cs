using UnityEngine;

[System.Serializable]
public class Interactable_Dialogue : MonoBehaviour, IInteractable
{
    public string npcName;

    [TextArea(3,10)] //box size
    public string[] sentences;

    public void Interact()
    {
        Debug.Log("Interacted");
    }
}
