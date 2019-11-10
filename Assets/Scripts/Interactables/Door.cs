using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Animator doorAnimControl;

    [HideInInspector]
    public bool open = false;
    [HideInInspector]
    public float animationSpeed = -1.0f;
    // Start is called before the first frame update
    public void Awake()
    {
        doorAnimControl = GetComponent<Animator>();
    }
}
