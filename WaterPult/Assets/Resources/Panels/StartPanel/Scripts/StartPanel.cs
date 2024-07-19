using System;
using System.Collections;
using System.Collections.Generic;
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
        playButton = this.transform.GetChild(1).GetComponent<Button>();
        quitButton = this.transform.GetChild(2).GetComponent<Button>();
        eventSystem.SetSelectedGameObject(playButton.gameObject);
        playButton.onClick.AddListener(OnPlay);
        quitButton.onClick.AddListener(OnQuit);
    }

    private void OnQuit()
    {
        Application.Quit();
    }

    private void OnPlay()
    {
        
    }
}
