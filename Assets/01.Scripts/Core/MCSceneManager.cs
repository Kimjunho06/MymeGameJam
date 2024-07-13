using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MCSceneManager : MonoSingleton<MCSceneManager> 
{
    public int CurrentSceneIndex = int.MaxValue;

    public bool IsResetScene;

    private void Start()
    {
        CurrentSceneIndex = GetSceneIndex();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            ResetScene();
        }

        if (Input.GetKeyDown(KeyCode.F1) && Input.GetKey(KeyCode.LeftControl))
        {
            ChangeScene();
        }
    }

    /// <summary>
    /// Change Index Scene
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void ChangeScene(int sceneIndex)
    {
        UIManager.Instance.FadeIn();

        StartCoroutine(NextSceneDelay(()=>
        {
            CurrentSceneIndex = sceneIndex;
            SceneManager.LoadScene(sceneIndex);
            IsResetScene = false;
        }));
    }

    /// <summary>
    /// Current Scene Next Scene
    /// </summary>
    public void ChangeScene() 
    {
        CurrentSceneIndex++;
        ChangeScene(CurrentSceneIndex);
    }

    public int GetSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void ResetScene()
    {
        if (CurrentSceneIndex == int.MaxValue)
        {
            Debug.LogError("Current Scene Index Is not Updated");
            return;
        }

        GameManager.Instance.deathCount++;
        ChangeScene(CurrentSceneIndex);
    }

    private IEnumerator NextSceneDelay(Action action)
    {
        while (!UIManager.Instance.IsFadeEnd)
        {
            yield return null;
        }
        action?.Invoke();
    }
}
