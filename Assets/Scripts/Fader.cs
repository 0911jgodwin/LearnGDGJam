using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Fader : MonoBehaviour
{
    [SerializeField] private CanvasGroup panel;
    public static Fader i { get; private set; }

    private void Awake()
    {
        i = this;
    }
    public IEnumerator FadeIn(float time)
    {
        yield return panel.DOFade(1f, time).WaitForCompletion();
    }

    public IEnumerator FadeOut(float time)
    {
        yield return panel.DOFade(0f, time).WaitForCompletion();
    }
}
