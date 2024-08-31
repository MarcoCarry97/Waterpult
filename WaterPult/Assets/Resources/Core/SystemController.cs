using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using ToolBox.Core;
using ToolBox.GUI;
using UnityEngine;

public class SystemController : MonoBehaviour
{
    public LevelAsset Level { get; set; }

    private List<Vase> vases;

    private Catapult catapult;

    private Coroutine coroutine;

    public int AvailableBullets { get; private set; }

    private enum State
    {
        Preparing,
        Playing,
        Result
    }

    private State state;

    private void Start()
    {
        state = State.Preparing;
        Level = null;
        vases = null;
    }



    private void Update()
    {

        switch(state)
        {
            case State.Preparing:
                PreparingState();
                break;
            case State.Playing:
                PlayingState();
                break;
            case State.Result:
                ResultState();
                break;
        }
    }

    private void UpdateGui()
    {
        Panel panel = GameController.Instance.Gui.GetActivePanel();
        GamePanel game = panel as GamePanel;
        if (game != null)
        {
            TextMeshProUGUI textview=game.GetComponentInChildren<TextMeshProUGUI>();
            textview.text=$": {AvailableBullets}";
        }
    }

    private void ResultState()
    {
        ResultPanel panel=GameController.Instance.Gui.GetActivePanel() as ResultPanel;
        bool allBloomed = vases.Select<Vase, bool>(vase => vase.IsBloomed()).Aggregate<bool>((acc, data) => acc && data);
        panel.Result = allBloomed ? "You Win!" : "Game Over";

    }

    private void PlayingState()
    {

        catapult =GameObject.FindObjectOfType<Catapult>();
        List<GameObject> runningBullets = GameObject.FindGameObjectsWithTag("Water").ToList<GameObject>();
        bool allDisappeared = runningBullets.Count() == 0;
        if (!catapult.HasBulletLoaded()&& AvailableBullets>0 && allDisappeared)
        {
            catapult.Load();
            AvailableBullets--;
            UpdateGui();
        }
        bool allBloomed = vases.Select<Vase, bool>(vase => vase.IsBloomed()).Aggregate<bool>((acc, data) => acc && data);
        bool allShot = AvailableBullets==0 && !catapult.HasBulletLoaded();
        runningBullets = GameObject.FindGameObjectsWithTag("Water").ToList<GameObject>();
        allDisappeared = runningBullets.Count() == 0;
        if (allBloomed || (allShot && allDisappeared))
        {
            GameController.Instance.Gui.ActivePanel("ResultPanel");
            state = State.Result;
        }
    }

    private void PreparingState()
    {
        if (Level != null && coroutine==null)
        {
            coroutine=StartCoroutine(Level.LoadScene(()=>
            {
                state = State.Playing;
                vases = GameObject.FindObjectsOfType<Vase>().ToList<Vase>();
                AvailableBullets = vases.Select<Vase, int>((vase) => vase.GetWaterNeeds() + 1).Aggregate<int>((acc, data) => acc + data);
                GameController.Instance.Gui.ActivePanel("GamePanel");
                coroutine= null;
            }));
            
        }
    }

    public void Clear()
    {
        Start();
    }

}
