using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;
using System.ComponentModel.Design.Serialization;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public Text nameText;
    [SerializeField] public Text dialogueText;
    [SerializeField] int lettersPerSecond;

    [SerializeField] GameObject DialogueBox;
    private Queue<string> sentences;
    private Queue<string> names;

    private void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Submit"))
            DisplayNextSentence();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        DialogueBox.SetActive(true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentence)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.name)
        {
            names.Enqueue(name);
        } 

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        nameText.text = name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }

    void EndDialogue()
    {
        DialogueBox.SetActive(false);
        Debug.Log("End of Conversation");
        return;
    }
}
