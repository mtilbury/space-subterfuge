using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private AudioSource audioSource;

    public static PlayAudio instance;

    public AudioClip unjailSFX;
    public AudioClip doorSFX;
    public AudioClip captureSFX;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlayOneShot(AudioClip sfx)
    {
        instance.audioSource.PlayOneShot(sfx);
    }
}
