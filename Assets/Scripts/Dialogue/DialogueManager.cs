using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using Learn.PlayerController;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public Text nameText;
    [SerializeField] public Text dialogueText;
    [SerializeField] int lettersPerSecond;
    public PlayerMovementInput playerInput;
    float musicVolume;
    bool lastSentence = false;
    bool typing = false;

    [SerializeField] GameObject DialogueBox;
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<string> clips;
    private IEnumerator triggerCoroutine;

    private void Update()
    {
        if (playerInput.SubmitPressed && !lastSentence && !typing)
        {
            AudioManager.i.StopVoice();
            DisplayNextSentence();
        }
    }

    public void StartDialogueWithTrigger(Dialogue dialogue, IEnumerator trigger)
    {
        triggerCoroutine = trigger;
        StartDialogue(dialogue);
    }
    public void StartDialogue(Dialogue dialogue)
    {
        musicVolume = AudioManager.i.musicSource.volume * 10;
        AudioManager.i.MusicVolume(musicVolume / 5);
        StartCoroutine(EnterBox());

        sentences = new Queue<string>();
        names = new Queue<string>();
        clips = new Queue<string>();

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

            if (name == "Teacher" || name == "Darth")
            {
                AudioManager.i.PlayVoice(clip);
            }
            else
            {
                StartCoroutine(AudioManager.i.PlayTyping(sentence.Length, lettersPerSecond));
            }

            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        typing = true;
        foreach (char letter in sentence.ToCharArray()) 
        { 
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        typing = false;
    }

    void EndDialogue()
    {
        
        StartCoroutine(ExitBox());
        AudioManager.i.MusicVolume(musicVolume);
        if (triggerCoroutine != null)
        {
            StartCoroutine(triggerCoroutine);
            triggerCoroutine = null;
        }
        return;
    }
    IEnumerator EnterBox()
    {
        Sequence s = DOTween.Sequence();
        s.Append(DialogueBox.transform.DOScale(new Vector3(1f, 1f, 0f), 1f));
        s.Join(DialogueBox.transform.DOMoveY(200f, 1f));
        yield return s.WaitForCompletion();
    }
    IEnumerator ExitBox()
    {
        Sequence s = DOTween.Sequence();
        s.Append(DialogueBox.transform.DOScale(new Vector3(0f, 0f, 0f), 1f));
        s.Join(DialogueBox.transform.DOMoveY(-200f, 1f));
        yield return s.WaitForCompletion();
    }
}
