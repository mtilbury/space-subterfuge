using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckAttackerWin : MonoBehaviour
{
    public Text numPointsText;
    public Text numPointsText2;
    public int numPointsToWin = 5;
    public Text AttackersWinText;
    public Text DefenderLoseText;

    private int numPoints = 0;

    public SceneFade fader;

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
        numPointsText.text = "Data: " + numPoints;
        numPointsText2.text = "Data: \n" + numPoints;
    }

    private IEnumerator AttackerWinScreen()
    {
        AttackersWinText.enabled = true;
        DefenderLoseText.enabled = true;
        yield return new WaitForSeconds(5.0f);
        fader.FadeToLevel(2);
        //SceneManager.LoadScene(2); // Go to menu
    }
}
