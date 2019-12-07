using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerInMainMenu : MonoBehaviour, HasController
{
    public Gamepad controller { get; set; }

    public Image button;

    public Color selectedColor;
    public Color defaultColor;

    private bool joined = false;

    public TitleScreenManager titleManager;
    public int playerID;

    // Update is called once per frame
    void LateUpdate()
    {
        if (button.IsActive() && controller != null && controller.aButton.isPressed)
        {
            // Change text color
            button.color = selectedColor;

            // Register readyup success
            joined = true;
            titleManager.RegisterReadyUp(playerID);
        }
        else if (joined)
        {
            button.color = defaultColor;
        }
    }
}
