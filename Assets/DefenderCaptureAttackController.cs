using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCaptureAttackController : MonoBehaviour
{
    public GameObject defenderCaptureAttack;

    private PlayerMovement defender_mov;

    private void Start()
    {
        defender_mov = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (defender_mov.controller.xButton.wasPressedThisFrame)
        {
            defenderCaptureAttack.SetActive(true);
        }
    }
}
