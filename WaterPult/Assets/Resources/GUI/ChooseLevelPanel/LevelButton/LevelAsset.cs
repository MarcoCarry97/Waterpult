using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="LevelAsset", menuName ="LevelAsset")]
public class LevelAsset : ScriptableObject
{

    [SerializeField]
    private string levelName;

    [SerializeField]
    private string sceneName;

    public string GetLevelName()
    { 
        return levelName;
    }

    public IEnumerator LoadScene(Action OnSceneLoaded)
    {
        AsyncOperation operation=SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
            yield return null;
        yield return new WaitForEndOfFrame();
        OnSceneLoaded();
        yield return new WaitForEndOfFrame();
    }
}
