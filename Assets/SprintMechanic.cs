using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintMechanic : MonoBehaviour
{
    public GameObject sprintUIGO;

    private PlayerMovement playerMove;
    private SprintUICooldown sprintUI;

    public float originalSpeed;
    public float sprintSpeed = 15.0f;

    public bool isSprinting = false;
    public bool canSprint = true;

    public bool inTutorial = false;
    public int id = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
        sprintUI = sprintUIGO.GetComponent<SprintUICooldown>();
        originalSpeed = playerMove.playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.controller != null)
        {
            if (playerMove.controller.xButton.isPressed && sprintUI.currentStamina < 1)
            {
                isSprinting = true;
                playerMove.playerSpeed = sprintSpeed;
            }
            else
            {
                isSprinting = false;
                playerMove.playerSpeed = originalSpeed;
            }
        }
    }
}
