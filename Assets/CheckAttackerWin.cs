using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckAttackerWin : MonoBehaviour
{
    public Text numPointsText;
    public Text numPointsText2;
    public Text numPointsText3;
    public Text numPointsText4;

    public int numPointsToWin = 5;
    public Text AttackersWinText;
    public Text DefenderLoseText;

    public GameObject miniCam;

    private int numPoints = 0;

    public SceneFade fader;

    public bool inTutorial = false;

    // Update is called once per frame
    void Update()
    {
        if(!inTutorial && numPoints >= numPointsToWin)
        {
            // Attackers win
            StartCoroutine(AttackerWinScreen());
        }
    }

    public void AddPoint()
    {
        numPoints++;
        numPointsText.text = "Data: " + numPoints + "/" + numPointsToWin;
        numPointsText2.text = "Data: " + numPoints + "/" + numPointsToWin;
        numPointsText3.text = "Data: " + numPoints + "/" + numPointsToWin;
        numPointsText4.text = "Data: " + numPoints + "/" + numPointsToWin;
    }

    private IEnumerator AttackerWinScreen()
    {
        //AttackersWinText.enabled = true;
        //DefenderLoseText.enabled = true;
        //miniCam.transform.position = new Vector3(200, 0, 200);
        yield return new WaitForSeconds(2.0f);
        fader.FadeToLevel(5);
        //SceneManager.LoadScene(2); // Go to menu
    }
}
