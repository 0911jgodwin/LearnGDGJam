using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerDialogue(IEnumerator trigger)
    {
        FindObjectOfType<DialogueManager>().StartDialogueWithTrigger(dialogue, trigger);
    }
}
