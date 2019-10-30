using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer_seconds = 60;
    private Text timer_text;
    private GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer");
        timer_text = timer.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get M:SS format for timer
        int minutes = Mathf.FloorToInt(timer_seconds / 60.0f);
        int seconds = Mathf.FloorToInt(timer_seconds - minutes * 60);
        string remaining_time = string.Format("{0:0}:{1:00}", minutes, seconds);

        timer_text.text = remaining_time;

        // Decrement by time since last frame
        timer_seconds -= Time.deltaTime;

        // If timer is less than 0, restart scene
        if (timer_seconds < 0)
            SceneManager.LoadScene(0);
    }
}
