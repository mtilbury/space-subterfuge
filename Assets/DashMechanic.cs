using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMechanic : MonoBehaviour
{
    public float dashTime = .5f;
    public float dashSpeed = 20.0f;
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
                playerMove.dashing = true;
            }
        }
    }
}
