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
    public GameObject AreaIndicator;
    [Space]
    public ParticleSystem hackParticle;

    private BoxCollider computerTrigger;

    private void Awake()
    {
        computerTrigger = GetComponent<BoxCollider>();
    }

    public void HackComputer()
    {
        computerTrigger.size = new Vector3(0f, 0f, 0f);
        computerTrigger.center = new Vector3(0f, 100f, 0f);
        StartCoroutine(DisableAfter());
        //computerTrigger.enabled = false;

        Instantiate(hackParticle, transform.position, Quaternion.identity);

        DefenderPrompt.gameObject.SetActive(false);
        DefenderTriangle.gameObject.SetActive(false);
        AttackerImage.gameObject.SetActive(true);
        DefenderImage.gameObject.SetActive(true);
        AreaIndicator.SetActive(false);


        if (OnComputerHacked != null)
        {
            OnComputerHacked.Invoke();
        }
    }

    private IEnumerator DisableAfter()
    {
        yield return null;
        computerTrigger.enabled = false;
    }
}
