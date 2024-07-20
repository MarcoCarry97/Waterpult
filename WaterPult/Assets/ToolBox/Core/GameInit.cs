using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolBox.Core;

namespace ToolBox.Core
{
    public class GameInit : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameController gameState = GameObject.FindObjectOfType<GameController>();
            if (gameState == null)
            {
                GameObject game = Resources.Load<GameObject>("Core/GameController");
                GameObject instance = Instantiate(game);
                gameState = instance.GetComponent<GameController>();
            }
            //gameState.Gui.Clear();
            //gameState.Gui.ActivePanel("StartPanel");
            Destroy(this.gameObject);
        }


    }

}
