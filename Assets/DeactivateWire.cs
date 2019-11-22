using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateWire : MonoBehaviour
{
    public DeactivateComputer parentComputer;

    private Material material;

    private void Awake()
    {
        parentComputer.OnComputerHacked += ChangeColor;
        material = GetComponent<Renderer>().material;
    }

    void ChangeColor()
    {
        Debug.Log("Shutting Off");
        material.SetVector("_SineOutput", new Vector2(0.0f, 0.0f));
    }
}
