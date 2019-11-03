using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnfreezeMechanic : MonoBehaviour
{
    public GameObject attacker;

    private PlayerMovement playerMove;

    public Text unfreezeInstruction;

    void Start()
    {
        playerMove = attacker.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerMove.controller != null)
        {
            if (playerMove.controller.yButton.wasPressedThisFrame)
            {
                Debug.Log("Controller reference works");
            }
        }
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
            //Debug.Log("Can free attacker");
            // Check if X was pressed
            if (playerMove.controller.xButton.wasPressedThisFrame)
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
