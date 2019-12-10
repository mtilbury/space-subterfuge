using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeText : MonoBehaviour
{
    public TMP_Text text;
    string textBody;

    [Header("Audio/SFX")]
    public AudioSource audio;
    public AudioClip intro;
    [Range(0, 1)]
    public float introVolume = 0.75f;
    public AudioClip beeping;
    [Range(0, 1)]
    public float beepVolume = 0.3f;

    

    [Header("Fading to Tutorial")]
    public SceneFade fader;
    public float timeToWait = 5.0f;

    public float typingTime = .15f;

    // Start is called before the first frame update
    void Awake()
    {
        textBody = text.text;
        text.text = "";
    }

    private void Start()
    {
        audio.PlayOneShot(intro, introVolume);
    }


    public void StartTyping()
    {
        Debug.Log("Started Typing");
        StartCoroutine(TypeOutText());
    }

    IEnumerator TypeOutText()
    {
        foreach(char c in textBody)
        {
            text.text += c;
            if(Random.Range(0, 1) < 0.1f)
            {
                audio.PlayOneShot(beeping, beepVolume);
            }
            yield return new WaitForSeconds(typingTime);
        }

        StartCoroutine(GoToTutorial());
    }

    IEnumerator GoToTutorial()
    {
        yield return new WaitForSeconds(5.0f);
        fader.FadeToLevel(1);
    }
}
