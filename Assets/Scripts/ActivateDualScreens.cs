using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDualScreens : MonoBehaviour
{
    public Camera OnePlayerCamera;
    public Camera ThreePlayerCamera;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(OnePlayerCamera.targetDisplay);
        Debug.Log("displays connected: " + Display.displays.Length);

        // Check if an additional display is available.
        if (Display.displays.Length > 1)
        {
            // If there's another display, stop cameras from being in split screen
            OnePlayerCamera.rect = new Rect(0, 0, 1, 1);
            ThreePlayerCamera.rect = new Rect(0, 0, 1, 1);

            // Set the 3P camera to show up on second display
            
            ThreePlayerCamera.targetDisplay = 1;

            // Activate second display
            Display.displays[1].Activate();
        }
            
    }
}
