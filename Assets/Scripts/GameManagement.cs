﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManagement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);

        if (Gamepad.current.startButton.wasPressedThisFrame)
            SceneManager.LoadScene(1);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
}