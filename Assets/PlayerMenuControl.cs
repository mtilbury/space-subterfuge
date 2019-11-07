using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMenuControl : MonoBehaviour, HasController
{
    public Gamepad controller { get; set; }

    public Text joinText;
    public Text joinedText;

    public Color selectedTextColor;
    public Color defaultTextColor = Color.white;

    // Update is called once per frame
    void Update()
    {
        if(controller != null)
        {
            joinText.enabled = false;
            joinedText.enabled = true;

            if (controller.aButton.isPressed)
            {
                // Change text color
                joinedText.color = selectedTextColor;
            }
            else
            {
                joinedText.color = defaultTextColor;
            }
        }
        else
        {
            joinText.enabled = true;
            joinedText.enabled = false;
        }
    }
}
