using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerInEndScene : MonoBehaviour, HasController
{
    public Gamepad controller { get; set; }

    public Image button;
    public Image button2;

    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;

    public Color selectedColorA;
    public Color defaultColorA;
    public Color selectedColorB;
    public Color defaultColorB;

    private bool joined = false;
    private bool aButton = false;

    public EndScreenManager endManager;
    public int playerID;

    private Vector3 defaultScale = Vector3.one;

    // Update is called once per frame
    void LateUpdate()
    {
        if (button.IsActive() && controller != null && controller.aButton.isPressed)
        {
            // Change text color
            button.color = selectedColorA;
            button.transform.localScale = defaultScale * 1.2f;
            text.text = "A";
            button2.color = selectedColorA;
            button2.transform.localScale = defaultScale * 1.2f;
            text2.text = "A";

            // Register readyup success
            joined = true;
            aButton = true;
            endManager.UnregisterReadyUp(playerID, false);
            endManager.RegisterReadyUp(playerID, true);
        }
        else if(button.IsActive() && controller != null && controller.bButton.isPressed)
        {
            // Change text color
            button.color = selectedColorB;
            text.text = "B";
            button.transform.localScale = defaultScale * 1.2f;
            button2.color = selectedColorB;
            text2.text = "B";
            button2.transform.localScale = defaultScale * 1.2f;

            // Register readyup success
            joined = true;
            aButton = false;
            endManager.UnregisterReadyUp(playerID, true);
            endManager.RegisterReadyUp(playerID, false);
        }
        else if (joined && aButton)
        {
            button.color = defaultColorA;
            button.transform.localScale = defaultScale;
            button2.color = defaultColorA;
            button2.transform.localScale = defaultScale;
        }
        else if (joined)
        {
            button.color = defaultColorB;
            button.transform.localScale = defaultScale;
            button2.color = defaultColorB;
            button2.transform.localScale = defaultScale;
        }
    }
}
