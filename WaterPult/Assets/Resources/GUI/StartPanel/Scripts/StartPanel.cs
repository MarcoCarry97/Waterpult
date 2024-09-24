using System;
using System.Collections;
using System.Collections.Generic;
using ToolBox.Core;
using ToolBox.GUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartPanel : Panel
{
    private Button playButton;
    private Button quitButton;

    private EventSystem eventSystem;

    private void Start()
    {
        eventSystem = EventSystem.current;
        playButton = this.transform.Find("ButtonGroup/StartButton").GetComponent<Button>();
        quitButton = this.transform.Find("ButtonGroup/QuitButton").GetComponent<Button>();
        //eventSystem.SetSelectedGameObject(playButton.gameObject);
        playButton.onClick.AddListener(OnPlay);
        quitButton.onClick.AddListener(OnQuit);
    }

    private void OnQuit()
    {
        Application.Quit();
    }

    private void OnPlay()
    {
        GameController.Instance.Gui.DeactivePanel();
        GameController.Instance.Gui.ActivePanel("ChooseLevelPanel");
    }
}
