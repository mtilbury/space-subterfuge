using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerInMainMenu : MonoBehaviour, HasController
{
    public Gamepad controller { get; set; }

    public Image button;
    public Image button2;

    public Color selectedColor;
    public Color defaultColor;

    private bool joined = false;

    public TitleScreenManager titleManager;
    public int playerID;

    public AudioClip beep;
    public AudioSource audioSource;

    private Vector3 defaultScale = Vector3.one;

    // Update is called once per frame
    void LateUpdate()
    {
        if (button.IsActive() && controller != null && controller.aButton.isPressed)
        {
            if(button.color != selectedColor)
            {
                audioSource.PlayOneShot(beep, 0.6f);
            }
            // Change text color
            button.color = selectedColor;
            button.transform.localScale = defaultScale * 1.2f;
            button2.color = selectedColor;
            button2.transform.localScale = defaultScale * 1.2f;

            // Register readyup success
            joined = true;
            titleManager.RegisterReadyUp(playerID);
        }
        else if (joined)
        {
            button.color = defaultColor;
            button.transform.localScale = defaultScale;
            button2.color = defaultColor;
            button2.transform.localScale = defaultScale;
        }
    }
}
