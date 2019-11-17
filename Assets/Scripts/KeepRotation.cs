using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotation : MonoBehaviour
{
    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float zRotation = -this.transform.parent.rotation.z;
        rect.rotation = Quaternion.Euler(0.0f, 0.0f, zRotation);

    }
}
