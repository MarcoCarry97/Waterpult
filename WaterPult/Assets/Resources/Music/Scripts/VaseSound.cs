using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip hitClip;

    [SerializeField]
    private AudioClip completeClip;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Play(AudioClip clip)
    {
        source.Stop();
        source.clip = clip;
        source.Play();
    }

    public void DoSoundHit()
    {
        Play(hitClip);
    }

    public void DoSoundComplete()
    {
        Play(completeClip);
    }
}
