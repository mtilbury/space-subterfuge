using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public HashSet<Gamepad> UsedGamepads;

    // Start is called before the first frame update
    void Start()
    {
        UsedGamepads = new HashSet<Gamepad>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Gamepad gamepad in Gamepad.all)
        {
            if (UsedGamepads.Contains(gamepad))
                continue;

            bool a_pressed_this_frame = gamepad.aButton.wasPressedThisFrame;

            if (Player1.GetComponent<PlayerMovement>().controller == null && a_pressed_this_frame)
            {
                Player1.GetComponent<PlayerMovement>().controller = gamepad;
                UsedGamepads.Add(gamepad);
                Debug.Log("player1 is online");
            }
            else if (Player2.GetComponent<PlayerMovement>().controller == null && a_pressed_this_frame)
            {
                Player2.GetComponent<PlayerMovement>().controller = gamepad;
                UsedGamepads.Add(gamepad);
                Debug.Log("player2 is online");
            }
        }

        
    }
}
