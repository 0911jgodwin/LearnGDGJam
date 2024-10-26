using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    public bool isRepeat = false;
    public Dialogue dialogue;

    public GameObject obj;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isRepeat)
        {
            TriggerDialogue();
            obj.SetActive(false);
        }
    }
}
