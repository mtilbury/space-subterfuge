using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingManager : MonoBehaviour
{
    [Header("Order: Attacker 1, 2, 3 ; Defender")]
    public Camera[] cameras;
    public Canvas[] canvases;

    public static PingManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public Camera GetCamera(int player)
    {
        return cameras[player];
    }

    public Canvas GetCanvas(int player)
    {
        return canvases[player];
    }
}
