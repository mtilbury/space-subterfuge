using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JailMechanic : MonoBehaviour
{
    public GameObject defender;
    public GameObject jailManagement;
    public GameObject jailSpawn;

    public Text jailInstruction;

    private PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = defender.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attacker"))
        {
            if (other.GetComponent<PlayerMovement>().canMove)
            {
                // Display instruction
                jailInstruction.enabled = true;
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Attacker"))
        {
            Debug.Log("Can jail Attacker");
            // Check if controller reference exists
            if (playerMove.controller != null)
            {
                // Check if X was pressed
                if (playerMove.controller.xButton.wasPressedThisFrame)
                {
                    JailManagement jail = jailManagement.GetComponent<JailManagement>();
                    other.gameObject.transform.position = jailSpawn.transform.position;
                    jail.jailedAttackers.Enqueue(other.gameObject);
                    Debug.Log("Player was jailed");
                    Debug.Log(jail.jailedAttackers.Count);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove instruction
        if (other.CompareTag("Attacker"))
        {
            jailInstruction.enabled = false;
        }
    }
}
