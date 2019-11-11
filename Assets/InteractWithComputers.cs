using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithComputers : MonoBehaviour
{
    private PlayerMovement player_mov;

    public GameObject ping;
    public Text instruction;
    public CheckAttackerWin point_collector;
    public float ping_scale = 1.0f;
    public float stealTime = 2.0f;

    public bool inTutorial = false;
    public int id = 1;

    private float _currentTime = 0.0f;
    private Coroutine _stealing = null;

    private void Start()
    {
        player_mov = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Computer"))
        {
            // Tell player to press A to steal info
            instruction.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Computer"))
        {
            // Check if A was pressed
<<<<<<< HEAD
            if (player_mov.controller.aButton.wasPressedThisFrame)
=======
            if (player_mov.controller.aButton.wasPressedThisFrame && _currentTime <= 0.0f)
>>>>>>> Stealing is based on time
            {
                _stealing = StartCoroutine(Stealing(other));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        instruction.enabled = false;
    }

    private IEnumerator Stealing(Collider other)
    {
        _currentTime = 0.0f;
        player_mov.canMove = false;
        while (_currentTime < stealTime)
        {
            _currentTime += Time.deltaTime;
            if (!player_mov.controller.aButton.isPressed)
            {
                _currentTime = 0.0f;
                player_mov.canMove = true;
                StopCoroutine(_stealing);
            }
            yield return null;
        }
        StealData(other);
    }


    private void StealData(Collider other)
    {
        // Spawn ping here
        GameObject spawned_ping = GameObject.Instantiate(ping);
        spawned_ping.transform.position = transform.position;
        spawned_ping.transform.position = new Vector3(transform.position.x, 8, transform.position.z);
        spawned_ping.transform.localScale = Vector3.one * ping_scale;

        // Disable instruction text
        instruction.enabled = false;

        // TODO: disable trigger
        other.gameObject.SetActive(false);

        // Add point
        point_collector.AddPoint();

        // If in tutorial, let manager know
        if (inTutorial)
        {
            TutorialManager.instance.RegisterSuccess(TutorialManager.instance.tasks.computer, id);
        }

        // Disabled Computer Models for Player Guidance 
        GameObject parent = other.gameObject.transform.parent.gameObject;
        parent.transform.GetChild(0).gameObject.SetActive(false);
        parent.transform.GetChild(1).gameObject.SetActive(false);
        parent.transform.GetChild(3).gameObject.SetActive(false);

        // Reset timer
        _currentTime = 0.0f;

        // Let the player move again
        player_mov.canMove = true;
    }
}
