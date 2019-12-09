using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnStart : MonoBehaviour
{
    public AudioClip hackingSFX;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = hackingSFX;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
