using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMechanic : MonoBehaviour
{
    public float dashDistance = 5;
    public float dashFraction = 0.1f;

    private PlayerMovement playerMove;


    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.controller != null)
        {
            if (playerMove.controller.aButton.wasPressedThisFrame)
            {
                transform.position = Vector3.Lerp(transform.position, transform.forward * dashDistance, dashFraction);
            }
        }
    }
}
