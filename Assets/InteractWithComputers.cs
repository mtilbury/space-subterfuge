using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithComputers : MonoBehaviour
{
    private PlayerMovement player_mov;

    public GameObject ping;
    public Text instruction;
    public CheckAttackerWin point_collector;
    public float ping_scale = 1.0f;
    public float stealRate = 20.0f;

    public bool inTutorial = false;
    public int id = 1;

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
        if (other.CompareTag("Computer")) {
            StealingProgress sp = other.gameObject.GetComponent<StealingProgress>();
            if (sp == null) return;


            // Spawn ping at start of hack
            if (player_mov.controller.aButton.wasPressedThisFrame)
            {
                if (gameObject.CompareTag("Attacker"))
                {
                    PingManager.Instance.SpawnPing(PingManager.PingTypes.Hacking, other.transform.position);
                }
            }
            // Check if A was pressed
            if (player_mov.controller.aButton.isPressed) {
                player_mov.canMove = false;
                if (gameObject.CompareTag("Attacker")) {
                    if (sp.AddProgress(stealRate * Time.deltaTime)) {
                        // stealing is done. allow them to move
                        StealData(other);
                        player_mov.canMove = true;
                    }
                    // stealing not done
                } else if (gameObject.CompareTag("Defender")) {
                    if (sp.RemoveProgress(stealRate * Time.deltaTime)) {
                        // unhacking is done. allow them to move
                        player_mov.canMove = true;
                    }
                    // unhacking not done
                }
            } else {
                player_mov.canMove = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        instruction.enabled = false;
    }


    private void StealData(Collider other)
    {
        /*
        // Spawn ping here
        GameObject spawned_ping = GameObject.Instantiate(ping);
        spawned_ping.transform.position = transform.position;
        spawned_ping.transform.position = new Vector3(transform.position.x, 8, transform.position.z);
        spawned_ping.transform.localScale = Vector3.one * ping_scale;
        */

        // Disable instruction text
        instruction.enabled = false;

        // TODO: disable trigger
        //other.gameObject.SetActive(false);
        other.gameObject.GetComponent<DeactivateComputer>().HackComputer();

        // Add point
        point_collector.AddPoint();

        // If in tutorial, let manager know
        if (inTutorial)
        {
            TutorialManager.instance.RegisterSuccess(TutorialManager.instance.tasks.computer, id);
        }

        // Disabled Computer Models for Player Guidance 
        GameObject parent = other.gameObject.transform.parent.gameObject;
        parent.transform.GetChild(0).gameObject.SetActive(false);
        parent.transform.GetChild(1).gameObject.SetActive(false);
        parent.transform.GetChild(3).gameObject.SetActive(false);
        parent.transform.GetChild(5).gameObject.SetActive(false);
    }
}
