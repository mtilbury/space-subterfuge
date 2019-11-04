using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckAttackerWin : MonoBehaviour
{
    public Text numPointsText;
    public int numPointsToWin = 5;

    private int numPoints = 0;

    // Update is called once per frame
    void Update()
    {
        if(numPoints > numPointsToWin)
        {
            // Attackers win
            SceneManager.LoadScene(0);
        }
    }

    public void AddPoint()
    {
        numPoints++;
        numPointsText.text = "Points: " + numPoints;
    }
}
