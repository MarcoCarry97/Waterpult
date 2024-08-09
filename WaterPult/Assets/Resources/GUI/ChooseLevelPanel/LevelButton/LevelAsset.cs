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

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
