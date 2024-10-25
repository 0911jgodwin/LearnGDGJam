using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor;
using System.Collections;

public class IntroMenu : MonoBehaviour
{
    [SerializeField] DialogueTrigger trigger;

    Fader fader;
    private void Start()
    {
        fader = GetComponent<Fader>();
        TriggerStory();
    }

    void TriggerStory()
    {
        trigger.TriggerDialogue(fader.Fading("Test Level"));
    }
}
