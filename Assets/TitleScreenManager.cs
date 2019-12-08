using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject StartButtonPrompt;
    public GameObject StartButtonPrompt2;

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

    private bool showingReadyUp = false;

    private void Start()
    {
        player_controllers = new List<HasController>
        {
            defender.GetComponent<HasController>(),
            attacker1.GetComponent<HasController>(),
            attacker2.GetComponent<HasController>(),
            attacker3.GetComponent<HasController>()
        };

        readyPlayers = new HashSet<int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!showingReadyUp)
        {
            // If START is pressed on any controller, show ready up screen
            foreach (HasController controller in player_controllers)
            {
                if (controller.controller != null && controller.controller.startButton.wasPressedThisFrame)
                {
                    showingReadyUp = true;
                    StartButtonPrompt.SetActive(false);
                    StartButtonPrompt2.SetActive(false);
                    ReadyUpPanel.SetActive(true);
                    ReadyUpPanel2.SetActive(true);
                }
            }
        }

        if (readyPlayers.Count == numPlayers)
        {
            fader.FadeToLevel(2);
        }
    }

    public void RegisterReadyUp(int playerID)
    {
        readyPlayers.Add(playerID);
    }
}
