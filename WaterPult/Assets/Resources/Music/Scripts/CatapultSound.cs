using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip stretchClip;

    [SerializeField]
    private AudioClip shotClip;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source=this.GetComponent<AudioSource>(); 
    }

    private void Play(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void DoSoundStretch()
    {
        Play(stretchClip);
    }

    public void DoSoundShot()
    {
        Play(shotClip);
    }
}
