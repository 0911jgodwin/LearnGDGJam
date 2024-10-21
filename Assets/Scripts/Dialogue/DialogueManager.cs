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
    float musicVolume;
    bool lastSentence = false;

    [SerializeField] GameObject DialogueBox;
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<string> clips;

    private void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        clips = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit") && !lastSentence)
        {
            AudioManager.i.StopVoice();
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Dialogue Started");
        musicVolume = AudioManager.i.musicSource.volume * 10;
        AudioManager.i.MusicVolume(musicVolume / 5);
        DialogueBox.SetActive(true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string name in dialogue.name)
        {
            names.Enqueue(name);
        }
        foreach (AudioClip clip in dialogue.audioClips)
        {
            if (clip != null)
            {
                string clipName = clip.name;
                clips.Enqueue(clipName);
            }
            else
            {
                clips.Enqueue (null);
            }
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (!lastSentence)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
            string name = names.Dequeue();
            string clip = clips.Dequeue();
            nameText.text = name;
            dialogueText.text = "";

            if (name == "Teacher")
            {
                AudioManager.i.PlayVoice(clip);
                Debug.Log("Teacher Voice");
            }
            else
            {
                StartCoroutine(AudioManager.i.PlayTyping(sentence.Length, lettersPerSecond));
                Debug.Log("Student Voice");
            }

            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        lastSentence = true;
        foreach (char letter in sentence.ToCharArray()) 
        { 
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        lastSentence = false;
    }

    void EndDialogue()
    {
        DialogueBox.SetActive(false);
        Debug.Log("End of Conversation");
        AudioManager.i.MusicVolume(musicVolume);
        return;
    }
}
