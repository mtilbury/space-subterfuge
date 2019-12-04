﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAlertManager : MonoBehaviour
{
    public static UIAlertManager instance;

    public Text ui_alert;
    public Text ui_alert_1;
    public Text ui_alert_2;
    public Text ui_alert_3;

    public float alert_time = 8.0f;

    private Queue<string> to_alert;
    private bool is_displaying_alert = false;

    private Coroutine curCoroutine;

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
        to_alert = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check queue for updates
        if(!is_displaying_alert && to_alert.Count > 0)
        {
            // If there's an alert, display it
            curCoroutine = StartCoroutine(DisplayText(to_alert.Dequeue()));
        }
    }

    private IEnumerator DisplayText(string alert)
    {
        is_displaying_alert = true;
        ui_alert_1.text = alert;
        ui_alert_2.text = alert;
        ui_alert_3.text = alert;
        yield return new WaitForSeconds(alert_time);
        //ui_alert.text = "";
        is_displaying_alert = false;
    }

    public void AddToQueue(string alert, bool bypass=false)
    {
        if (bypass)
        {
            StopCoroutine(curCoroutine);
            is_displaying_alert = false;
        }
        to_alert.Enqueue(alert);
    }

}
