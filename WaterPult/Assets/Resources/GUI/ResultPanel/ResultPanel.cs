using System.Collections;
using System.Collections.Generic;
using TMPro;
using ToolBox.Core;
using ToolBox.GUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultPanel : Panel
{
    public string Result {  get; set; }

    private TextMeshProUGUI textview;

    private Button playAgainButton;

    private Button quitButton;


    // Start is called before the first frame update
    void Start()
    {
        textview=this.GetComponentInChildren<TextMeshProUGUI>();
        playAgainButton=this.transform.Find("ButtonGroup/PlayAgainButton").GetComponent<Button>();
        quitButton=this.transform.Find("ButtonGroup/QuitButton").GetComponent<Button>();
        playAgainButton.onClick.AddListener(OnPlayAgain);
        quitButton.onClick.AddListener(OnQuit);
        Result = "";
    }

    private void Update()
    {
        textview.text = Result;
    }

    private void OnPlayAgain()
    {
        GameController.Instance.System.Clear();
        GameController.Instance.Gui.Clear();
        GameController.Instance.Gui.ActivePanel("ChooseLevelPanel");
    }

    private void OnQuit()
    {
        GameController.Instance.System.Clear();
        GameController.Instance.Gui.Clear();
        SceneManager.LoadScene("MainScene");
    }
}
