using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    Fader fader;

    private void Start()
    {
        fader = GetComponent<Fader>();
    }
    public void PlayGame()
    {
        StartCoroutine(fader.Fading("IntroScene"));
    }
    public void Options()
    {
        SceneManager.LoadSceneAsync("OptionsMenu", LoadSceneMode.Additive);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        // DELETE BEFORE FINAL BUILD
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
