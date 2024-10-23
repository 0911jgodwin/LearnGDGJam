using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public Image black;
    public Animator anim;

    public IEnumerator Fading(string scene)
    {
        Debug.Log("Fader Start");
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadSceneAsync(scene);
        Debug.Log("Fader End");
    }
}
