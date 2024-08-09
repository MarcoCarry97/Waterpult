using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ToolBox.Core;
using UnityEngine;

public class SystemController : MonoBehaviour
{
    public LevelAsset Level { get; set; }

    private List<Vase> vases;

    private int numberOfBullets;

    private Catapult catapult;

    private int shotBullets;

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
        shotBullets= 0;
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

    private void ResultState()
    {
        
    }

    private void PlayingState()
    {

        catapult =GameObject.FindObjectOfType<Catapult>();
        if(catapult.HasBulletLoaded() && shotBullets<numberOfBullets)
        {
            catapult.Load();
            shotBullets++;
        }
        bool allBloomed = vases.Select<Vase, bool>(vase => vase.IsBloomed()).Aggregate<bool>((acc, data) => acc && data);
        bool allShot = shotBullets == numberOfBullets && !catapult.HasBulletLoaded();
        if (allBloomed || allShot)
        {
            GameController.Instance.Gui.ActivePanel("ResultPanel");
            state = State.Result;
        }
    }

    private void PreparingState()
    {
        if (Level != null)
        {
            Level.LoadScene();
            state = State.Playing;
            vases = GameObject.FindObjectsOfType<Vase>().ToList<Vase>();
            numberOfBullets = vases.Select<Vase, int>((vase) => vase.GetWaterNeeds() + 1).Aggregate<int>((acc, data )=> acc + data);
            GameController.Instance.Gui.ActivePanel("GamePanel");
        }
    }


}
