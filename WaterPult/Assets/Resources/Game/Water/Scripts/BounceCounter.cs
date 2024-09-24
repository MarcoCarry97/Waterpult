using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BounceCounter : MonoBehaviour
{
    public int Count {  get; set; }

    private TextMeshProUGUI textview;

    private void Start()
    {
        Count = 0;
        textview=this.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        textview.text = $"{Count}";
    }

}
