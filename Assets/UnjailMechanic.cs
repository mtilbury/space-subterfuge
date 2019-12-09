using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnjailMechanic : MonoBehaviour
{
    public GameObject jailManagement;

    public Transform jailExitWest;
    public Transform jailExitNorth;
    public Transform jailExitEast;
    public Transform jailExitSouth;

    public bool canUnjail = true;
    public float unjailCooldown = 5.0f;

    private PlayerMovement playerMove;
    private JailManagement jail;

    //public Text unjailInstruction;
    public GameObject unjailButtonPrompt;

    public bool inTutorial = false;
    public int id = 1;

    private List<Transform> jailExits;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
        jail = jailManagement.GetComponent<JailManagement>();

        jailExits = new List<Transform>
        {
            jailExitWest,
            jailExitNorth,
            jailExitEast,
            jailExitSouth
        };
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jail Gate") && jail.jailedAttackers.Count > 0)
        {
            // Display instruction
            //unjailInstruction.enabled = true;
            unjailButtonPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Jail Gate"))
        {
            if(jail.jailedAttackers.Count <= 0)
            {
                unjailButtonPrompt.SetActive(false);
            }

            // Check if X was pressed
            if (playerMove.controller != null)
            {
                if (playerMove.controller.aButton.wasPressedThisFrame)
                {
                    if (jail.jailedAttackers.Count > 0 && canUnjail)
                    {
                        // If in tutorial, let manager know
                        if (inTutorial)
                        {
                            TutorialManager.instance.RegisterSuccess(TutorialManager.instance.tasks.jail, id);
                        }

                        canUnjail = false;
                        GameObject jailedAttacker = jail.jailedAttackers.Dequeue();

                        // Find closest jailExit
                        float minDistance = Mathf.Abs(Vector3.Distance(transform.position, jailExitWest.position));
                        Transform closestJailExit = jailExitWest;
                        foreach(Transform jailExit in jailExits)
                        {
                            float dist = Mathf.Abs(Vector3.Distance(transform.position, jailExit.position));
                            if(dist < minDistance)
                            {
                                minDistance = dist;
                                closestJailExit = jailExit;
                            }
                        }

                        jailedAttacker.transform.parent.position = closestJailExit.position;
                        jailedAttacker.transform.localPosition = Vector3.zero;
                        jailedAttacker.transform.parent.Find("Attacker Graphics").localPosition = Vector3.zero;
                        
                        // If there's another in jail, free them too!
                        if(jail.jailedAttackers.Count > 0)
                        {
                            GameObject jailedAttacker2 = jail.jailedAttackers.Dequeue();
                            jailedAttacker2.transform.parent.position = closestJailExit.position;
                            jailedAttacker2.transform.localPosition = Vector3.zero;
                            jailedAttacker2.transform.parent.Find("Attacker Graphics").localPosition = Vector3.zero;

                        }
                        StartCoroutine(UnjailCooldown());
                        Debug.Log("Attacker freed from jail");

                        PlayAudio.PlayOneShot(PlayAudio.instance.unjailSFX);

                        PingManager.Instance.SpawnPing(PingManager.PingTypes.UnJail, transform.position);

                        
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove instruction
        if (other.CompareTag("Jail Gate"))
        {
            //unjailInstruction.enabled = false;
            unjailButtonPrompt.SetActive(false);

        }
    }

    private IEnumerator UnjailCooldown()
    {
        yield return new WaitForSeconds(unjailCooldown);
        canUnjail = true;
    }
}
