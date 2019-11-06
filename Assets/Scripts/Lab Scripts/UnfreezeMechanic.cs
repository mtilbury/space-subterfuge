using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UnfreezeMechanic : MonoBehaviour
{
    public GameObject attacker;

    private PlayerMovement playerMove;

    public Text unfreezeInstruction;

    void Start()
    {
        playerMove = attacker.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attacker") && !other.GetComponent<PlayerMovement>().canMove)
        {
            // Display instruction
            unfreezeInstruction.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Attacker"))
        {
            // Check if X was pressed
            if (playerMove.controller != null && playerMove.controller.xButton.wasPressedThisFrame)
            {
                other.GetComponent<PlayerMovement>().canMove = true;
                Debug.Log("Player freed");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove instruction
        unfreezeInstruction.enabled = false;
    }
}
