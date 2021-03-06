﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManagerDefender : MonoBehaviour
{
    public class Tasks
    {
        public int capture;
        public int door;
        public int teleport;

        public Tasks(int c, int d, int t)
        {
            capture = c;
            door = d;
            teleport = t;
        }
    }

    public Tasks tasks = new Tasks(0, 1, 2);

    public GameObject captureDoor;
    public GameObject doorDoor;
    public GameObject teleportDoor;

    private List<GameObject> task_walls;
    private int current_task;
    private bool done = false;

    public bool tutorialFinished = false;

    public Text waitForPlayers;

    public static TutorialManagerDefender instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        current_task = tasks.capture;

        task_walls = new List<GameObject>()
        {
            captureDoor,
            doorDoor,
            teleportDoor
        };

        UIAlertManagerDefender.instance.AddToQueue("Your goal is to send all the attackers to the jail.");
        UIAlertManagerDefender.instance.AddToQueue("Press 'X' to capture an attacker.");
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            task_walls[current_task].SetActive(false);
            current_task++;
            done = false;

            if(current_task == tasks.door)
            {
                UIAlertManagerDefender.instance.AddToQueue("Open doors with 'A'", true);
            }
            if(current_task == tasks.teleport)
            {
                UIAlertManagerDefender.instance.AddToQueue("Use the pink teleporters to move across the map quickly.", true);
            }
            if(current_task > tasks.teleport)
            {
                tutorialFinished = true;
                //waitForPlayers.enabled = true;
                UIAlertManagerDefender.instance.AddToQueue("Waiting for other players...", true);
            }
        }
    }

    public void RegisterSuccess(int task_id)
    {
        if (task_id != current_task)
            return;

        done = true;
    }
}
