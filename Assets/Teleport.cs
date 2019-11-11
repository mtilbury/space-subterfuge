using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject begin;
    public GameObject end;
    public bool canTeleport = true;

    public bool inTutorialDefender = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Defender"))
        {
            if (canTeleport && end.GetComponent<Teleport>().canTeleport)
            {
                canTeleport = false;
                other.transform.position = end.transform.position;
                if (inTutorialDefender)
                {
                    TutorialManagerDefender.instance.RegisterSuccess(TutorialManagerDefender.instance.tasks.teleport);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Defender"))
        {
            if (!canTeleport)
            {

            }
            else
            {
                canTeleport = true;
                end.GetComponent<Teleport>().canTeleport = true;
            }
        }
    }
}
