using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateComputer : MonoBehaviour
{
    public delegate void OnComputerHackedDelegate();
    public OnComputerHackedDelegate OnComputerHacked;

    public RectTransform DefenderPrompt;
    public GameObject DefenderTriangle;
    public RectTransform AttackerImage;
    public RectTransform DefenderImage;
    [Space]
    public ParticleSystem hackParticle;

    private BoxCollider computerTrigger;

    private void Awake()
    {
        computerTrigger = GetComponent<BoxCollider>();
    }

    public void HackComputer()
    {
        computerTrigger.enabled = false;

        Instantiate(hackParticle, transform.position, Quaternion.identity);

        DefenderPrompt.gameObject.SetActive(false);
        DefenderTriangle.gameObject.SetActive(false);
        AttackerImage.gameObject.SetActive(true);
        DefenderImage.gameObject.SetActive(true);


        if (OnComputerHacked != null)
        {
            OnComputerHacked.Invoke();
        }
    }
}
