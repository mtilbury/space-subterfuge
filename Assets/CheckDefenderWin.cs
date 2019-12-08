using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckDefenderWin : MonoBehaviour
{
    /*
    public GameObject Attacker1;
    public GameObject Attacker2;
    public GameObject Attacker3;
    */
    public GameObject jailManagement;
    public Text DefenderWinText;
    public Text AttackersLoseText;
    public int jailCount;

    public GameObject miniCam;

    /*
    private PlayerMovement Attacker1_mov;
    private PlayerMovement Attacker2_mov;
    private PlayerMovement Attacker3_mov;
    */

    public SceneFade fader;

    // Start is called before the first frame update
    void Start()
    {
        /*
        Attacker1_mov = Attacker1.GetComponent<PlayerMovement>();
        Attacker2_mov = Attacker2.GetComponent<PlayerMovement>();
        Attacker3_mov = Attacker3.GetComponent<PlayerMovement>();
        */
        jailCount = jailManagement.GetComponent<JailManagement>().jailedAttackers.Count;
    }

    // Update is called once per frame
    void Update()
    {
        // If all players can't move, the defender wins
        /*
        if(!Attacker1_mov.canMove && !Attacker2_mov.canMove && !Attacker3_mov.canMove)
        {
            StartCoroutine(DefenderWinScreen());
        }
        */
        jailCount = jailManagement.GetComponent<JailManagement>().jailedAttackers.Count;
        if (jailCount == 3)
        {
            Debug.Log(jailCount);
            StartCoroutine(DefenderWinScreen());
        }
    }

    private IEnumerator DefenderWinScreen()
    {
        //DefenderWinText.enabled = true;
        //AttackersLoseText.enabled = true;
        //miniCam.transform.position = new Vector3(200, 0, 200);
        yield return new WaitForSeconds(2.0f);
        fader.FadeToLevel(4);
        //SceneManager.LoadScene(2); // Go to menu

    }
}
