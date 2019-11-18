using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashUICooldown : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 10.0f;
    public bool isCooldown;
    public GameObject player;

    private PlayerMovement playerMov;

    private void Start()
    {
        playerMov = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerMov.controller != null)
        {
            if (playerMov.controller.bButton.wasPressedThisFrame)
            {
                isCooldown = true;
                imageCooldown.fillAmount = 1;
            }
        }

        if (isCooldown)
        {
            imageCooldown.fillAmount -= 1 / cooldown * Time.deltaTime;

            if (imageCooldown.fillAmount <= 0)
            {
                //imageCooldown.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
