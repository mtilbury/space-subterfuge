﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithComputers : MonoBehaviour
{
    private PlayerMovement player_mov;

    public GameObject ping;
    public Text instruction;

    private void Start()
    {
        player_mov = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Computer"))
        {
            // Tell player to press A to steal info
            instruction.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Computer"))
        {
            // Check if A was pressed
            if (player_mov.controller.aButton.wasPressedThisFrame)
            {
                // TODO: Add one to player score

                // Spawn ping here
                GameObject spawned_ping = GameObject.Instantiate(ping);
                spawned_ping.transform.position = transform.position;
                spawned_ping.transform.position = new Vector3(transform.position.x, -2, transform.position.z);

                // Disable instruction text
                instruction.enabled = false;

                // TODO: disable trigger
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        instruction.enabled = false;
    }
}