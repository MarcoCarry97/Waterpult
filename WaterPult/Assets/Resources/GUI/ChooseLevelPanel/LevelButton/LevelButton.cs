using System.Collections;
using System.Collections.Generic;
using ToolBox.Core;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    private LevelAsset asset;

    private void Start()
    {
        Button button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        GameController.Instance.System.Level = asset;
        GameController.Instance.Gui.DeactivePanel();
    }
}
