using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Learn.PlayerController;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public bool isRepeat = false;
    public Dialogue dialogue;
    public bool bestowsAbility = false;
    public int abilityToBestow = 0;
    private GameObject player;
    public bool finishDialogue = false;

    public GameObject obj;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogueWithTrigger(dialogue, BasicTest(player));
    }

    public void TriggerDialogue(IEnumerator trigger)
    {
        FindObjectOfType<DialogueManager>().StartDialogueWithTrigger(dialogue, trigger);
    }

    IEnumerator SetAbilityActive(GameObject playerObject)
    {
        playerObject.GetComponent<PlayerController>().EnableBehaviour(abilityToBestow);
        playerObject.GetComponent<PlayerController>().ChattingAway = false;
        yield return player;
    }

    IEnumerator BasicTest(GameObject playerObject) 
    {
        playerObject.GetComponent<PlayerController>().ChattingAway = false;
        yield return player;
    }

    IEnumerator EndGame()
    {
        
        yield return player;
        SceneManager.LoadScene("ReplayScene");
        Debug.Log("Test");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isRepeat)
        {
            player = collision.gameObject;
            player.GetComponent<PlayerController>().ChattingAway = true;
            if (finishDialogue)
                TriggerDialogue(EndGame());
            else
            {
                if (!bestowsAbility)
                {
                    TriggerDialogue();
                }
                else
                {
                    TriggerDialogue(SetAbilityActive(player));
                }
            }
            obj.SetActive(false);
        }
    }
}
