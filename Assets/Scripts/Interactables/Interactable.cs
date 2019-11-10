using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public bool isOneUse = true;

    public virtual void Interact()
    {
        Debug.Log("Do Something");
    }
}
