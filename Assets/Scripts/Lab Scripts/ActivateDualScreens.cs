using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDualScreens : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("displays connected: " + Display.displays.Length);

        // Check if an additional display is available.
        if (Display.displays.Length > 1)
        {
            // Activate second display
            Display.displays[1].Activate();
        }

        Screen.SetResolution(1920, 1080, true);
    }
}
