using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    //List<Gamepad> game_pads;

    //Gamepad Player1Controller;
    //Gamepad Player2Controller;

    // Start is called before the first frame update
    void Start()
    {
        //Player1Controller = Player1.GetComponent<PlayerMovement>().controller;
        //Player2Controller = Player2.GetComponent<PlayerMovement>().controller;
    }

    // Update is called once per frame
    void Update()
    {
        Gamepad active_gamepad = Gamepad.current;

        bool a_pressed_this_frame = active_gamepad.aButton.wasPressedThisFrame;

        if (Player1.GetComponent<PlayerMovement>().controller == null && a_pressed_this_frame)
        {
            Player1.GetComponent<PlayerMovement>().controller = active_gamepad;
            Debug.Log("player1 is online");
        }
        else if (Player2.GetComponent<PlayerMovement>().controller == null && a_pressed_this_frame)
        {
            Player2.GetComponent<PlayerMovement>().controller = active_gamepad;
            Debug.Log("player2 is online");
        }
    }
}
