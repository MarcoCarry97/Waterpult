using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletCount : MonoBehaviour
{
    public int Count { get; set; }

    private TextMeshProUGUI textview;

    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        textview=this.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       // textview.text=$": {Count}";
    }
}
