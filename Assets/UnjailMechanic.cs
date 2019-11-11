using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnjailMechanic : MonoBehaviour
{
    public GameObject jailManagement;
    public GameObject jailExit;
    public bool canUnjail = true;
    public float unjailCooldown = 5.0f;

    private PlayerMovement playerMove;
    private JailManagement jail;

    public Text unjailInstruction;

    public bool inTutorial = false;
    public int id = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
        jail = jailManagement.GetComponent<JailManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jail Gate") && jail.jailedAttackers.Count > 0)
        {
            // Display instruction
            unjailInstruction.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Jail Gate"))
        {
            // Check if X was pressed
            if (playerMove.controller != null)
            {
                if (playerMove.controller.xButton.wasPressedThisFrame)
                {
                    if (jail.jailedAttackers.Count > 0 && canUnjail)
                    {
                        canUnjail = false;
                        GameObject temp = jail.jailedAttackers.Dequeue();
                        temp.transform.position = jailExit.transform.position;
                        StartCoroutine(UnjailCooldown());
                        Debug.Log("Attacker freed from jail");

                        // If in tutorial, let manager know
                        if (inTutorial)
                        {
                            TutorialManager.instance.RegisterSuccess(TutorialManager.instance.tasks.jail, id);
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove instruction
        if (other.CompareTag("Attacker"))
        {
            unjailInstruction.enabled = false;
        }
    }

    private IEnumerator UnjailCooldown()
    {
        yield return new WaitForSeconds(unjailCooldown);
        canUnjail = true;
    }
}
