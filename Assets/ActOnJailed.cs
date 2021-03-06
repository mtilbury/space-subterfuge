﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActOnJailed : MonoBehaviour
{
    public JailManagement jail;
    public GameObject jailCage;
    public GameObject jailSpawn;
    public GameObject hoppingPlayer;
    public GameObject playerGraphics;

    public AudioClip jailSFX;
    public AudioSource audioSource;

    private bool jailing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool act()
    {
        bool temp = !jailing;
        if (!jailing)
            StartCoroutine(actOnJail());
        return temp;
    }

    private IEnumerator actOnJail()
    {
        jailing = true;
        gameObject.GetComponent<PlayerMovement>().enabled = false;

        PingManager.Instance.SpawnPing(PingManager.PingTypes.Jailed, transform.position);

        if (jailSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(jailSFX);
        }

        jailCage.SetActive(true);
        jailCage.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        jailCage.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        hoppingPlayer.transform.position = new Vector3(jailCage.transform.position.x, jailCage.transform.position.y - 3, jailCage.transform.position.z);
        transform.localPosition = Vector3.zero;
        playerGraphics.transform.localPosition = Vector3.zero;
        yield return null;

        // Get bigger
        int frame = 0;
        while(frame < 15)
        {
            hoppingPlayer.transform.position = new Vector3(jailCage.transform.position.x, jailCage.transform.position.y - 2, jailCage.transform.position.z);
            transform.localPosition = Vector3.zero;
            playerGraphics.transform.localPosition = Vector3.zero;
            jailCage.transform.localScale = new Vector3(jailCage.transform.localScale.x + (1 - jailCage.transform.localScale.x) * .4f, jailCage.transform.localScale.y + (1 - jailCage.transform.localScale.y) * .4f, jailCage.transform.localScale.z + (1 - jailCage.transform.localScale.z) * .4f);
            frame++;
            yield return null;
        }

        frame = 0;
        while(frame < 24)
        {
            jailCage.transform.position = new Vector3(jailCage.transform.position.x, jailCage.transform.position.y, jailCage.transform.position.z);
            jailCage.transform.localScale = new Vector3(jailCage.transform.localScale.x - .04f, jailCage.transform.localScale.y - .04f, jailCage.transform.localScale.z - .04f);
            hoppingPlayer.transform.localScale = jailCage.transform.localScale;
            hoppingPlayer.transform.position = new Vector3(jailCage.transform.position.x, jailCage.transform.position.y - jailCage.transform.localScale.x * 2, jailCage.transform.position.z);
            transform.localPosition = Vector3.zero;
            playerGraphics.transform.localPosition = Vector3.zero;
            frame++;
            yield return null;
        }

        jail.jailedAttackers.Enqueue(gameObject);
        transform.localPosition = Vector3.zero;
        hoppingPlayer.transform.position = jailSpawn.transform.position;
        playerGraphics.transform.localPosition = Vector3.zero;
        hoppingPlayer.transform.localScale = Vector3.one;
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        jailCage.SetActive(false);
        jailing = false;
    }
}
