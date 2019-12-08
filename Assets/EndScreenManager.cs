using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenManager : MonoBehaviour
{
    //public GameObject StartButtonPrompt;
    //public GameObject StartButtonPrompt2;

    public GameObject ReadyUpPanel;
    public GameObject ReadyUpPanel2;

    public GameObject defender;
    public GameObject attacker1;
    public GameObject attacker2;
    public GameObject attacker3;
    private List<HasController> player_controllers;

    public int numPlayers;
    public SceneFade fader;

    private HashSet<int> readyPlayers;
    private HashSet<int> menuPlayers;

    private bool showingReadyUp = false;

    public float secondsBeforeReadyUp = 2.0f;

    private void Start()
    {
        //player_controllers = new List<HasController>
        //{
        //    defender.GetComponent<HasController>(),
        //    attacker1.GetComponent<HasController>(),
        //    attacker2.GetComponent<HasController>(),
        //    attacker3.GetComponent<HasController>()
        //};

        StartCoroutine(ShowReadyUpInSeconds());

        readyPlayers = new HashSet<int>();
        menuPlayers = new HashSet<int>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!showingReadyUp)
        //{
        //    // If START is pressed on any controller, show ready up screen
        //    foreach (HasController controller in player_controllers)
        //    {
        //        if (controller.controller != null && controller.controller.startButton.wasPressedThisFrame)
        //        {
        //            showingReadyUp = true;
        //            StartButtonPrompt.SetActive(false);
        //            StartButtonPrompt2.SetActive(false);
        //            ReadyUpPanel.SetActive(true);
        //            ReadyUpPanel2.SetActive(true);
        //        }
        //    }
        //}

        if (readyPlayers.Count == numPlayers)
        {
            fader.FadeToLevel(3);
        }
        else if (menuPlayers.Count == numPlayers)
        {
            fader.FadeToLevel(1);
        }
    }

    public void RegisterReadyUp(int playerID, bool aButton)
    {
        if (aButton)
        {
            readyPlayers.Add(playerID);
        }
        else
        {
            menuPlayers.Add(playerID);
        }
        
    }

    public void UnregisterReadyUp(int playerID, bool aButton)
    {
        if (aButton)
        {
            if(readyPlayers.Contains(playerID))
                readyPlayers.Remove(playerID);
        }
        else
        {
            if (menuPlayers.Contains(playerID))
                menuPlayers.Remove(playerID);
        }
    }

    private IEnumerator ShowReadyUpInSeconds()
    {
        yield return new WaitForSeconds(secondsBeforeReadyUp);
        ReadyUpPanel.SetActive(true);
        ReadyUpPanel2.SetActive(true);
    }
}
