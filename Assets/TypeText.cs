using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeText : MonoBehaviour
{
    public TMP_Text text;
    string textBody;

    public float typingTime = .15f;

    // Start is called before the first frame update
    void Awake()
    {
        textBody = text.text;
        text.text = "";
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
            yield return new WaitForSeconds(typingTime);
        }
    }
}
