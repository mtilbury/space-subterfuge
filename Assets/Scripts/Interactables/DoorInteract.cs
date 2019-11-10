using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : Interactable
{
    public Animator doorAnimControl;

    bool open = false;
    float animationSpeed = -1.0f;

    public void Awake()
    {
        isOneUse = false;
    }

    public override void Interact()
    {
        Debug.Log("Opening Door.");
        //doorAnimControl.speed *= -1.0f;
        doorAnimControl.SetFloat("Direction", animationSpeed);
        if (open)
        {
            doorAnimControl.Play("Door", 0, 0.0f);
            open = false;
        }
        else if (!open)
        {
            doorAnimControl.Play("Door", 0, 1.0f);
            open = true;
        }
        animationSpeed *= -1.0f;
    }
}
