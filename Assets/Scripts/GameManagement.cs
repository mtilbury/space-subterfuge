using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManagement : MonoBehaviour
{
    public bool inMenu = true;
    public SceneFade fader;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Alpha0))
            fader.FadeToLevel(0);

        if (Input.GetKeyDown(KeyCode.Alpha1))
            fader.FadeToLevel(1);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            fader.FadeToLevel(2);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            fader.FadeToLevel(3);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            fader.FadeToLevel(4);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            fader.FadeToLevel(5);

        if (inMenu && Gamepad.current.startButton.wasPressedThisFrame)
            fader.FadeToLevel(1);
    }

    public void startGame()
    {
        fader.FadeToLevel(1);
    }
}
