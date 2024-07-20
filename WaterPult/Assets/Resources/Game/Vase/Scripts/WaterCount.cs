using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaterCount : MonoBehaviour
{
    public int Count {  get; set; }

    private TextMeshProUGUI textView;

    private void Start()
    {
        Count = 0;
        textView = this.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        textView.text = Count.ToString();
    }
}
