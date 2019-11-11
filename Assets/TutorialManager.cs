using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public struct Tasks
    {
        public int computer;
        public int jail;
        public int door;
        public int dash;

        public Tasks(int c, int j, int b, int d)
        {
            computer = c;
            jail = j;
            door = b;
            dash = d;
        }
    }

    public Tasks tasks = new Tasks(0, 1, 2, 3);

    [System.Serializable]
    public class Task
    {
        public GameObject attacker1_wall;
        public GameObject attacker2_wall;
        public GameObject attacker3_wall;
    }

    public Task computer_task;
    public Task jail_task;
    public Task door_task;
    public Task dash_task;

    public static TutorialManager instance;

    private HashSet<int> playersWhoSucceededCurrentTask;
    private int current_task;
    private List<Task> task_walls;

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

    private void Start()
    {
        playersWhoSucceededCurrentTask = new HashSet<int>();
        current_task = tasks.computer;

        task_walls = new List<Task>()
        {
            computer_task,
            jail_task,
            door_task,
            dash_task
        };

        UIAlertManager.instance.AddToQueue("Your goal is to hack computers and avoid getting caught.");
    }

    // Update is called once per frame
    void Update()
    {
        if(playersWhoSucceededCurrentTask.Count == 3)
        {
            // Delete walls
            task_walls[current_task].attacker1_wall.SetActive(false);
            task_walls[current_task].attacker2_wall.SetActive(false);
            task_walls[current_task].attacker3_wall.SetActive(false);

            current_task++;
            playersWhoSucceededCurrentTask.Clear();

            if(current_task == tasks.jail)
            {
                // Display jail text
                UIAlertManager.instance.AddToQueue("If you get caught, you'll be sent to jail. Press X to free other attackers.");
            }

            if(current_task == tasks.door)
            {
                UIAlertManager.instance.AddToQueue("Hit a button to open a door with 'A'");
            }

            if(current_task == tasks.dash)
            {
                UIAlertManager.instance.AddToQueue("Press B to do a dash!");
                UIAlertManager.instance.AddToQueue("Press B to do a dash!");
            }

        }

        if(current_task > tasks.dash)
        {
            // Done
            SceneManager.LoadScene(1);
        }
    }

    public void RegisterSuccess(int task_id, int player_id)
    {
        Debug.Log("task " + task_id + " player_id " + player_id);
        if (task_id != current_task)
            return;

        Debug.Log("Added");
        playersWhoSucceededCurrentTask.Add(player_id);
    }
}
