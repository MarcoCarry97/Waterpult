using System;
using System.Collections;
using System.Collections.Generic;
using ToolBox.Core;
using ToolBox.GUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : Panel
{
    private Button playButton;
    private Button quitButton;

    private EventSystem eventSystem;

    private void Start()
    {
        eventSystem = EventSystem.current;
        playButton = this.transform.GetChild(1).GetComponent<Button>();
        quitButton = this.transform.GetChild(2).GetComponent<Button>();
        eventSystem.SetSelectedGameObject(playButton.gameObject);
        playButton.onClick.AddListener(OnPlay);
        quitButton.onClick.AddListener(OnQuit);
    }

    private void OnQuit()
    {
        Time.timeScale = 1;
        GameController.Instance.Gui.Clear();
        GameController.Instance.System.Clear();
        SceneManager.LoadScene("MainScene");
    }

    private void OnPlay()
    {
        Time.timeScale = 1;
        GameController.Instance.Gui.DeactivePanel();
    }
}
