using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JailEventUI : MonoBehaviour
{
    public bool jailed = false;
    public Image jailBars;
    public Image jailBackground;
    public Image FadeToBlack;

    // Update is called once per frame
    void Update()
    {
        if (jailed)
        {
            StartCoroutine(JailUI());
        }
    }

    private IEnumerator JailUI()
    {
        int frame = 0;
        jailBars.enabled = true;
        jailBackground.enabled = true;

        while (frame < 40)
        {
            Color tempColor = FadeToBlack.color;
            tempColor.a = tempColor.a + (1 / 40);
            FadeToBlack.color = tempColor;
            yield return null;
        }

        Color fullBlack = FadeToBlack.color;
        fullBlack.a = 1f;
        FadeToBlack.color = fullBlack;

        jailBars.enabled = false;
        jailBackground.enabled = false;

        frame = 0;

        while (frame < 20)
        {
            Color tempColor = FadeToBlack.color;
            tempColor.a = tempColor.a - (1 / 20);
            FadeToBlack.color = tempColor;
            yield return null;
        }

        Color noBlack = FadeToBlack.color;
        noBlack.a = 0f;
        FadeToBlack.color = noBlack;

        jailed = false;
        Debug.Log("JailUI.ajiled set to false");
    }
}
