using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMechanic : MonoBehaviour
{
    public float dashTime = .5f;
    public float dashCooldown = 10.0f;
    public float dashSpeed = 60.0f;
    public float dashFraction = 0.1f;

    public bool canDash = true;

    private PlayerMovement playerMove;

    public bool inTutorial = false;
    public int id = 1;


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
            if (playerMove.controller.xButton.wasPressedThisFrame && canDash)
            {
                canDash = false;
                StartCoroutine(Dash());
                if (inTutorial)
                {
                    TutorialManager.instance.RegisterSuccess(TutorialManager.instance.tasks.dash, id);
                }
            }
        }
    }

    private IEnumerator Dash()
    {
        float originalSpeed = playerMove.playerSpeed;
        playerMove.playerSpeed = dashSpeed;
        StartCoroutine(DashCooldown());

        yield return new WaitForSeconds(dashTime);

        playerMove.playerSpeed = originalSpeed;
    }

    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        Debug.Log("Attacker can dash");
    }
}
