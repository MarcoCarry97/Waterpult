using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAsset : ScriptableObject
{
    [SerializeField]
    private string levelName;

    [SerializeField]
    private Scene scene;

    public void LoadScene()
    {
        SceneManager.LoadScene(scene.name);
    }
}
