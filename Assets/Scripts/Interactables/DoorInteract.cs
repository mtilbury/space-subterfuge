using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : Interactable
{
    public Door door;

    public float doorCooldown = 5.0f;
    private bool onCooldown;
    private float doorCooldownTimer;
    private BoxCollider doorTrigger;

    [Space]
    [Header("Color Options")]
    public Color activeColor;
    public Color inactiveColor;

    private float pingTime = 8.0f;
    private float pingTimer = 0.0f;

    private bool pingActive;

    public DoorInteract linkedDoor;
    public Renderer doorRenderer;
    public Renderer linkedDoorRenderer;
    private Material material;
    private Material linkedDoorMaterial;

    public void Awake()
    {
        doorTrigger = GetComponent<BoxCollider>();
        onCooldown = false;
        doorCooldownTimer = 0.0f;

        isOneUse = false;
        pingTimer = 0.0f;
        pingActive = false;
        material = doorRenderer.material;
        linkedDoorMaterial = linkedDoorRenderer.material;

        material.SetColor("_Color", activeColor);
        linkedDoorMaterial.SetColor("_Color", activeColor);
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

        if (onCooldown)
        {
            doorCooldownTimer -= Time.deltaTime;

            if(doorCooldownTimer <= 0.0f)
            {
                onCooldown = false;
                EnableDoor();
                linkedDoor.EnableDoor();
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

        onCooldown = true;
        DisableDoor();
        linkedDoor.DisableDoor();
        doorCooldownTimer = doorCooldown;

        // Play sound effect
        PlayAudio.PlayOneShot(PlayAudio.instance.doorSFX);
    }

    public void EnableDoor()
    {
        doorTrigger.enabled = true;
        material.SetColor("_Color", activeColor);
        linkedDoorMaterial.SetColor("_Color", activeColor);
    }

    public void DisableDoor()
    {
        doorTrigger.enabled = false;
        material.SetColor("_Color", inactiveColor);
        linkedDoorMaterial.SetColor("_Color", inactiveColor);
    }
}
