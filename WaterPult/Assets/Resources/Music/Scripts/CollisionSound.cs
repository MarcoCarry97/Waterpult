using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollisionSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip;

    private AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Bounce!");
        sound.Stop();
        sound.clip = clip;
        sound.Play();
    }
}
