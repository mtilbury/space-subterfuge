using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadManager : MonoBehaviour
{
    public GameObject Defender;
    public GameObject Attacker1;
    public GameObject Attacker2;
    public GameObject Attacker3;

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

            if (Defender.GetComponent<PlayerMovement>().controller == null && a_pressed_this_frame)
            {
                Defender.GetComponent<PlayerMovement>().controller = gamepad;
                UsedGamepads.Add(gamepad);
                Debug.Log("Defender is online");
            }
            else if (Attacker1.GetComponent<PlayerMovement>().controller == null && a_pressed_this_frame)
            {
                Attacker1.GetComponent<PlayerMovement>().controller = gamepad;
                UsedGamepads.Add(gamepad);
                Debug.Log("Attacker 1 is online");
            }
            else if (Attacker2.GetComponent<PlayerMovement>().controller == null && a_pressed_this_frame)
            {
                Attacker2.GetComponent<PlayerMovement>().controller = gamepad;
                UsedGamepads.Add(gamepad);
                Debug.Log("Attacker 2 is online");
            }
            else if (Attacker3.GetComponent<PlayerMovement>().controller == null && a_pressed_this_frame)
            {
                Attacker3.GetComponent<PlayerMovement>().controller = gamepad;
                UsedGamepads.Add(gamepad);
                Debug.Log("Attacker 3 is online");
            }
        }

        
    }
}
