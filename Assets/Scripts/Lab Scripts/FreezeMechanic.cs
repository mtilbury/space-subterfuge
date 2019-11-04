using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeMechanic : MonoBehaviour
{
    public GameObject defender;

    private PlayerMovement playerMove;

    public Text freezeInstruction;

    private void Start()
    {
        playerMove = defender.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attacker") && other.GetComponent<PlayerMovement>().canMove)
        {
            // Display instruction
            freezeInstruction.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Attacker"))
        {
            Debug.Log("Can freeze attacker");
            // Check if X was pressed
            if (playerMove.controller.xButton.wasPressedThisFrame)
            {
                other.GetComponent<PlayerMovement>().canMove = false;
                Debug.Log("Player frozen");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove instruction
        freezeInstruction.enabled = false;
    }
}
