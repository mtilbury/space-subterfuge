using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JailMechanic : MonoBehaviour
{
    public GameObject jailManagement;
    public GameObject jailSpawn;

    private JailManagement jail;

    public bool inTutorialDefender = false;

    // Start is called before the first frame update
    void Start()
    {
        jail = jailManagement.GetComponent<JailManagement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Attacker") && !other.name.Contains("Follower"))
        {
            other.transform.position = jailSpawn.transform.position;
            jail.jailedAttackers.Enqueue(other.gameObject);
            Debug.Log("Player was jailed");
            Debug.Log(jail.jailedAttackers.Count);

            if (inTutorialDefender)
            {
                TutorialManagerDefender.instance.RegisterSuccess(TutorialManagerDefender.instance.tasks.capture);
            }
        }
    }
}
