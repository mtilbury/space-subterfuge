using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        UIAlertManagerDefender.instance.AddToQueue("Your goal is to capture all of the attackers.");
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
                UIAlertManagerDefender.instance.AddToQueue("Open doors with 'A'");
            }
            if(current_task == tasks.door)
            {
                UIAlertManagerDefender.instance.AddToQueue("Use these to teleport across the map quickly.");
            }
            if(current_task > tasks.door)
            {
                tutorialFinished = true;
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
