using UnityEngine;

public class LevelScene : MonoBehaviour
{
    Fader fader;
    [SerializeField] DialogueTrigger trigger;
    private void Start()
    {
        fader = GetComponent<Fader>();
    }
}
