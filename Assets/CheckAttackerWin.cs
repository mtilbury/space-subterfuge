﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckAttackerWin : MonoBehaviour
{
    public Text numPointsText;
    public int numPointsToWin = 5;
    public Text AttackersWinText;
    public Text DefenderLoseText;

    private int numPoints = 0;

    // Update is called once per frame
    void Update()
    {
        if(numPoints >= numPointsToWin)
        {
            // Attackers win
            StartCoroutine(AttackerWinScreen());
        }
    }

    public void AddPoint()
    {
        numPoints++;
        numPointsText.text = "Points: " + numPoints;
    }

    private IEnumerator AttackerWinScreen()
    {
        AttackersWinText.enabled = true;
        DefenderLoseText.enabled = true;
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(0); // Go to menu
    }
}