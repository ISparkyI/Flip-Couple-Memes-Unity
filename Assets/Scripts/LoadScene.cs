using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] public GameObject loadingScreen = null;

    public void loadScene(string sceneName)
    {
        StartCoroutine(StartLoad(sceneName));
    }

    public void loadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void exitFromApp()
    {
        Application.Quit();
    }

    IEnumerator StartLoad(string sceneName)
    {
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true);
            yield return StartCoroutine(FadeLoadingScreen(1, 1));
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            while (!operation.isDone)
            {
                yield return null;
            }
            loadingScreen.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    IEnumerator FadeLoadingScreen(float targetValue, float duration)
    {
        float startValue = loadingScreen.GetComponent<CanvasGroup>().alpha;
        float time = 0;
        while (time < duration)
        {
            loadingScreen.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        loadingScreen.GetComponent<CanvasGroup>().alpha = targetValue;
    }
}