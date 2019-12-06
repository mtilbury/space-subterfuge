using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintUICooldown : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldownStamina = 6.0f;
    public float maxStamina = 3.0f;
    public float currentStamina = 0.0f;
    public float scalingFactor = 0.05f;
    public Vector3 originalScaling;
    public Vector3 maxScaling;
    public PlayerMovement playerMove;
    public SprintMechanic sprintMove;

    public bool cooldownDelayActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.controller != null)
        {
            if (sprintMove.isSprinting)
            {
                currentStamina += 1 / maxStamina * Time.deltaTime;
                imageCooldown.fillAmount = currentStamina;

                if (transform.localScale.x < maxScaling.x)
                {
                    transform.localScale += new Vector3(scalingFactor, scalingFactor, scalingFactor);
                }

                if (imageCooldown.fillAmount >= 1)
                {
                    //cooldownDelayActive = true;
                    sprintMove.canSprint = false;
                }
            }
            else
            {
                if (transform.localScale.x >= originalScaling.x)
                {
                    transform.localScale -= new Vector3(scalingFactor, scalingFactor, scalingFactor);

                }

                if (currentStamina <= 0)
                {
                    return;
                }
                currentStamina -= 1 / cooldownStamina * Time.deltaTime;
                imageCooldown.fillAmount = currentStamina;
            }
        }
    }
    /*
    private IEnumerator SprintRefillDelay()
    {
        yield return new WaitForSeconds(1.0f);

    }
    */
}
