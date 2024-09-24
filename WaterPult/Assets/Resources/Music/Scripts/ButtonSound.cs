using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour, ISelectHandler
{
    private AudioSource source;

    private Button button;

    [SerializeField]
    private AudioClip selectedClip;

    [SerializeField]
    private AudioClip submitClip;



    private void Start()
    {

        source = GetComponent<AudioSource>();
        button=GetComponent<Button>();
        button.onClick.AddListener(Submitted);
    }

 

    private void Submitted()
    {
        source.Stop();
        source.clip = submitClip;
        source.Play();
    }

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        source.clip = selectedClip;
        source.Play();
    }
}
