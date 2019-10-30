using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Capture : MonoBehaviour
{
    private float captureTimer = 3.0f;

    public Text captureTimerText;

    private void OnTriggerStay (Collider other) 
    {
        if (other.tag == "Computer") 
        {
            captureTimer -= Time.deltaTime;
            captureTimerText.text = Mathf.RoundToInt(captureTimer).ToString();
            if (captureTimer <= 0) 
            {
                Destroy(other.transform.parent.gameObject);
                captureTimerText.text = "";
            }
        }
    }
    
    private void OnTriggerExit (Collider other) 
    {
        if (other.tag == "Computer") 
        {
            captureTimerText.text = "";
            captureTimer = 3.0f;
        }
    }
}
