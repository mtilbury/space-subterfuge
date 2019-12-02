using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JailMechanic : MonoBehaviour
{
    public GameObject jailManagement;
    public GameObject jailSpawn;

    public GameObject defender;

    public LayerMask linecastMask;

    private JailManagement jail;

    public bool inTutorialDefender = false;
    private int defenderTutorialCaptured = 0;

    public AudioClip jailSFX;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        jail = jailManagement.GetComponent<JailManagement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Attacker") && !other.name.Contains("Follower"))
        {
            // Make sure nothing is in the way
            if(Physics.Linecast(defender.transform.position, other.gameObject.transform.position, linecastMask))
            {
                Debug.Log("Blocked!");
                Debug.DrawLine(defender.transform.position, other.gameObject.transform.position, Color.green, 100f, false);
                return;
            }

            //
            //other.transform.position = jailSpawn.transform.position;
            //jail.jailedAttackers.Enqueue(other.gameObject);
            other.GetComponent<ActOnJailed>().act();
            Debug.Log("Player was jailed");
            Debug.Log(jail.jailedAttackers.Count);

            PingManager.Instance.SpawnPing(PingManager.PingTypes.Jailed, transform.position);

            if(jailSFX != null && audioSource != null)
            {
                audioSource.PlayOneShot(jailSFX);
            }

            if (inTutorialDefender)
            {
                defenderTutorialCaptured++;
                if(defenderTutorialCaptured >= 3)
                {
                    TutorialManagerDefender.instance.RegisterSuccess(TutorialManagerDefender.instance.tasks.capture);
                }
            }
        }
    }
}
