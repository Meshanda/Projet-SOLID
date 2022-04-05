using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeCoroutine : MonoBehaviour
{
    [SerializeField] [Range(0, 1)]private float fadeSpeed;
    [SerializeField] private Image fadeImage;
    [SerializeField] private BoolVariable fadeOutFinished;
    [SerializeField] private StringVariable fadeScene;

    private IEnumerator Start()
    {
        fadeOutFinished.Value = false;
        yield return StartCoroutine(FadeOut());
        fadeOutFinished.Value = true;
        yield return StartCoroutine(FadeIn());
        fadeOutFinished.Value = false;
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(fadeScene.Value));
    }

    private IEnumerator FadeIn()
    {
        while (fadeImage.color.a > 0)
        {
            fadeImage.color -= new Color(0, 0, 0, fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }
    private IEnumerator FadeOut()
    {
        while (fadeImage.color.a < 1)
        {
            fadeImage.color += new Color(0, 0, 0, fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
