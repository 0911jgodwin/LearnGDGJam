using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
    }
    public void QuitLevel()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
