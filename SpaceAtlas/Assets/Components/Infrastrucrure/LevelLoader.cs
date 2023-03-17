using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // ����� �������� �����
    public void LoadScene(int sceneIndex, MonoBehaviour corouniteStarter, Action onLoaded = null)
    {
        corouniteStarter.StartCoroutine(LoadSceneAsync(sceneIndex, onLoaded));

    }


    // ������������ ����� �������� �����
    private IEnumerator LoadSceneAsync(int sceneIndex, Action onLoaded)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncOperation.isDone) // ���� ����� �� ����������
        {
            yield return null;
        }
        onLoaded?.Invoke();
    }
}
