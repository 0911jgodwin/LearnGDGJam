using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
    }
    public void Options()
    {
        SceneManager.LoadSceneAsync("OptionsMenu", LoadSceneMode.Additive);
    }
    public void QuitLevel()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
