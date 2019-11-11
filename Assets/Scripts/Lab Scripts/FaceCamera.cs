using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Camera targetCamera;

    private void LateUpdate()
    {
        this.transform.up =  - targetCamera.transform.forward;
    }
}
