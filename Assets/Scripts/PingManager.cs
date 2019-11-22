using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingManager : MonoBehaviour
{
    public enum PingTypes {Default, Door, Teleport, Hacking, Jailed, Help, UnJail};

    public GameObject[] Pings;

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

    public GameObject SpawnPing(PingTypes pingType, Vector3 spawnPosition)
    {
        GameObject newPing;

        switch (pingType)
        {
            case PingTypes.Door:
                newPing = Instantiate(Pings[1]);
                newPing.transform.position = spawnPosition;
                return newPing; 
            case PingTypes.Teleport:
                newPing = Instantiate(Pings[2]);
                newPing.transform.position = spawnPosition;
                return newPing;
            case PingTypes.Hacking:
                newPing = Instantiate(Pings[3]);
                newPing.transform.position = spawnPosition;
                return newPing;
            case PingTypes.Jailed:
                newPing = Instantiate(Pings[4]);
                newPing.transform.position = spawnPosition;
                return newPing;
            case PingTypes.Help:
                newPing = Instantiate(Pings[5]);
                newPing.transform.position = spawnPosition;
                return newPing; ;
            case PingTypes.UnJail:
                newPing = Instantiate(Pings[6]);
                newPing.transform.position = spawnPosition;
                return newPing; ;
            default:
                newPing = Instantiate(Pings[0]);
                newPing.transform.position = spawnPosition;
                return newPing;
        }
    }
}
