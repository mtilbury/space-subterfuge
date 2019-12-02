using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    public PlayerMovement defender;
    public PlayerMovement attacker1;
    public PlayerMovement attacker2;
    public PlayerMovement attacker3;

    public Text countdownAttackers;
    public Text countdownDefender;

    public int countdownStart = 4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }
    
    private IEnumerator Countdown()
    {
        defender.enabled = false;
        defender.canMove = false;
        attacker1.enabled = false;
        attacker1.canMove = false;
        attacker2.enabled = false;
        attacker2.canMove = false;
        attacker3.enabled = false;
        attacker3.canMove = false;

        int countdownInt = countdownStart;
        while(countdownInt > 0)
        {
            countdownAttackers.text = countdownInt.ToString();
            countdownDefender.text = countdownInt.ToString();
            yield return new WaitForSeconds(1.0f);
            countdownInt--;
        }

        countdownAttackers.text = "Start!";
        countdownDefender.text = "Start!";

        defender.enabled = true;
        defender.canMove = true;
        attacker1.enabled = true;
        attacker1.canMove = true;
        attacker2.enabled = true;
        attacker2.canMove = true;
        attacker3.enabled = true;
        attacker3.canMove = true;

        yield return new WaitForSeconds(0.5f);

        int numFrames = 0;
        while(numFrames < 60)
        {
            countdownAttackers.color = new Color(countdownAttackers.color.r, countdownAttackers.color.g, countdownAttackers.color.b, countdownAttackers.color.a - (1.0f / 60));
            countdownDefender.color = new Color(countdownDefender.color.r, countdownDefender.color.g, countdownDefender.color.b, countdownDefender.color.a - (1.0f / 60));
            yield return null;
            numFrames++;
        }

        gameObject.SetActive(false);
    }
}
