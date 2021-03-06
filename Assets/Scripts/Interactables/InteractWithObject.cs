﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithObject : MonoBehaviour
{
    private PlayerMovement player_mov;

    public GameObject ping;
    public GameObject interactPrompt;

    public float pingHeight = 8.0f;
    public float pingScale = 3.0f;

    public float coolDown = 1.0f;
    float coolDownTimer;

    bool onCoolDown;

    public bool inTutorial = false;
    public bool inTutorialDefender = false;
    public int id = 1;

    private void Start()
    {
        player_mov = GetComponent<PlayerMovement>();
        onCoolDown = false;
    }

    private void Update()
    {
        if (onCoolDown)
        {
            coolDownTimer -= Time.deltaTime;
            if(coolDownTimer <= 0.0f)
            {
                onCoolDown = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interact"))
        {
            // Tell player to press A to steal info
            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interact"))
        {
            if (!onCoolDown)
            {
                // Check if A was pressed
                if (player_mov.controller.aButton.wasPressedThisFrame)
                {
                    Debug.Log("Pressed Button.");
                    // Interact with the object
                    Interactable interactable  = other.GetComponent<Interactable>();
                    interactable.Interact();

                    /*
                    // Spawn ping here
                    GameObject spawned_ping = Instantiate(ping);
                    spawned_ping.transform.position = new Vector3(transform.position.x, pingHeight, transform.position.z);
                    spawned_ping.transform.rotation = Quaternion.Euler(90, 0, 0);
                    spawned_ping.transform.localScale = new Vector3(pingScale, pingScale, 1.0f);
                    */

                    
                    // Disable instruction text
                    //if(interactable.isOneUse)
                        interactPrompt.SetActive(false);
                    onCoolDown = true;
                    coolDownTimer = coolDown;

                    if (inTutorial)
                    {
                        TutorialManager.instance.RegisterSuccess(TutorialManager.instance.tasks.door, id);
                    }
                    if (inTutorialDefender)
                    {
                        TutorialManagerDefender.instance.RegisterSuccess(TutorialManagerDefender.instance.tasks.door);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactPrompt.SetActive(false);
    }
}
