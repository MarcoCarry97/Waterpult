using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ToolBox.Core;
using ToolBox.GUI;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : Panel
{
    private BulletCount bulletCount;

    private Button pauseButton;

    public int Count { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        bulletCount=this.GetComponentInChildren<BulletCount>();
        pauseButton=this.GetComponentInChildren<Button>();
        pauseButton.onClick.AddListener(OnPause);
        Count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bulletCount.Count = Count;

    }

    private void OnPause()
    {
        GameController.Instance.Gui.ActivePanel("PausePanel");
        Time.timeScale = 0;
    }
}
