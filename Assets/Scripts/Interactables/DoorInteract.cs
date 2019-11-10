using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : Interactable
{
    public Door door;

    public void Awake()
    {
        isOneUse = false;
    }

    public override void Interact()
    {
        Debug.Log("Opening Door.");
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
