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
            other.transform.position = jailSpawn.transform.position;
            jail.jailedAttackers.Enqueue(other.gameObject);
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
