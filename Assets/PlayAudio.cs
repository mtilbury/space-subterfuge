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

    private bool playingJail = false;

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

    public void PlayOneShot(AudioClip sfx)
    {
        if(sfx == instance.unjailSFX)
        {
            if (instance.playingJail)
            {
                return;
            }
            StartCoroutine(DontAllowUnjailSound());
            
        }
        instance.audioSource.PlayOneShot(sfx);
    }

    private IEnumerator DontAllowUnjailSound()
    {
        instance.playingJail = true;
        yield return new WaitForSeconds(4.0f);
        instance.playingJail = false;
    }
}
