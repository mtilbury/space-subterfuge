using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadManager : MonoBehaviour
{
    // Singleton!
    public static GamepadManager instance;

    // Maintain set of tracked gamepads
    private static HashSet<Gamepad> UsedGamepads;

    // Maintain map of player => controller
    private static Dictionary<int, Gamepad> ControllerMap;

    // Are all gamepads populated?
    private bool allGamepadsPopulated = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UsedGamepads = new HashSet<Gamepad>();
        ControllerMap = new Dictionary<int, Gamepad>
        {
            { 1, null },
            { 2, null },
            { 3, null },
            { 4, null }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (!allGamepadsPopulated)
        {
            foreach (Gamepad gamepad in Gamepad.all)
            {
                if (UsedGamepads.Contains(gamepad))
                    continue;

                bool a_pressed_this_frame = gamepad.aButton.wasPressedThisFrame;

                if (ControllerMap[1] == null && a_pressed_this_frame)
                {
                    ControllerMap[1] = gamepad;
                    UsedGamepads.Add(gamepad);
                    Debug.Log("Defender is online");
                }
                else if (ControllerMap[2] == null && a_pressed_this_frame)
                {
                    ControllerMap[2] = gamepad;
                    UsedGamepads.Add(gamepad);
                    Debug.Log("Attacker 2 is online");
                }
                else if (ControllerMap[3] == null && a_pressed_this_frame)
                {
                    ControllerMap[3] = gamepad;
                    UsedGamepads.Add(gamepad);
                    Debug.Log("Attacker 3 is online");
                }
                else if (ControllerMap[4] == null && a_pressed_this_frame)
                {
                    ControllerMap[4] = gamepad;
                    UsedGamepads.Add(gamepad);
                    Debug.Log("Attacker 4 is online");
                    allGamepadsPopulated = true;
                }
            }
        }
    }

    public static Gamepad getPlayerController(int playerID)
    {
        return ControllerMap[playerID];
    }
}
