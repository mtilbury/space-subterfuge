using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : Interactable
{
    public Door door;

    private float pingTime = 8.0f;
    private float pingTimer = 0.0f;

    private bool pingActive;

    public void Awake()
    {
        isOneUse = false;
        pingTimer = 0.0f;
        pingActive = false;
    }

    private void Update()
    {
        if (pingActive)
        {
            pingTimer -= Time.deltaTime;

            if(pingTimer <= 0.0f)
            {
                pingActive = false;
            }
        }
    }

    public override void Interact()
    {
        Debug.Log("Opening Door.");

        if (!pingActive)
        {
            PingManager.Instance.SpawnPing(PingManager.PingTypes.Door, door.transform.position);
            pingTimer = pingTime;
            pingActive = true;
        }

        //doorAnimControl.speed *= -1.0f;
        door.doorAnimControl.SetFloat("Direction", door.animationSpeed);
        if (door.open)
        {
            door.doorAnimControl.Play("Door", 0, 0.0f);
            door.open = false;
        }
        else if (!door.open)
        {
            door.doorAnimControl.Play("Door", 0, 1.0f);
            door.open = true;
        }
        door.animationSpeed *= -1.0f;
    }
}
