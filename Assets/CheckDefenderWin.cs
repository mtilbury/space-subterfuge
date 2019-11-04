using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckDefenderWin : MonoBehaviour
{
    public GameObject Attacker1;
    public GameObject Attacker2;
    public GameObject Attacker3;

    private PlayerMovement Attacker1_mov;
    private PlayerMovement Attacker2_mov;
    private PlayerMovement Attacker3_mov;

    // Start is called before the first frame update
    void Start()
    {
        Attacker1_mov = Attacker1.GetComponent<PlayerMovement>();
        Attacker2_mov = Attacker2.GetComponent<PlayerMovement>();
        Attacker3_mov = Attacker3.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // If all players can't move, the defender wins
        if(!Attacker1_mov.canMove && !Attacker2_mov.canMove && !Attacker3_mov.canMove)
        {
            SceneManager.LoadScene(0); // Go to menu
        }
    }
}
