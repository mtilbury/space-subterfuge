﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerManager : MonoBehaviour
{
    public GameObject GamepadManagerPrefab;

    // Players
    public GameObject defender;
    public GameObject attacker1;
    public GameObject attacker2;
    public GameObject attacker3;

    // Direct access to players' movement components
    private HasController defender_mov;
    private HasController attacker1_mov;
    private HasController attacker2_mov;
    private HasController attacker3_mov;

    private int numControllers = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate a GamepadManager
        Instantiate(GamepadManagerPrefab);

        defender_mov = defender.GetComponent<HasController>();
        attacker1_mov = attacker1.GetComponent<HasController>();
        attacker2_mov = attacker2.GetComponent<HasController>();
        attacker3_mov = attacker3.GetComponent<HasController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(numControllers < 4)
        {
            // Try to get defender gamepad
            Gamepad defender_gp = GamepadManager.getPlayerController(1);
            if (defender_gp != null && defender_mov.controller == null)
            {
                numControllers++;
                defender_mov.controller = defender_gp;
            }

            // Try to get attacker1 gamepad
            Gamepad attacker1_gp = GamepadManager.getPlayerController(2);
            if(attacker1_gp != null && attacker1_mov.controller == null)
            {
                numControllers++;
                attacker1_mov.controller = attacker1_gp;
            }

            // Try to get attacker1 gamepad
            Gamepad attacker2_gp = GamepadManager.getPlayerController(3);
            if (attacker2_gp != null && attacker2_mov.controller == null)
            {
                numControllers++;
                attacker2_mov.controller = attacker2_gp;
            }

            // Try to get attacker1 gamepad
            Gamepad attacker3_gp = GamepadManager.getPlayerController(4);
            if (attacker3_gp != null && attacker3_mov.controller == null)
            {
                numControllers++;
                attacker3_mov.controller = attacker3_gp;
            }
        }
    }
}
