using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // метод загрузки сцены
    public void LoadScene(int sceneIndex, MonoBehaviour corouniteStarter, Action onLoaded = null)
    {
        corouniteStarter.StartCoroutine(LoadSceneAsync(sceneIndex, onLoaded));

    }


    // Ассинхронный метод загрузки сцены
    private IEnumerator LoadSceneAsync(int sceneIndex, Action onLoaded)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncOperation.isDone) // пока сцена не загрузилсь
        {
            yield return null;
        }
        onLoaded?.Invoke();
    }
}
