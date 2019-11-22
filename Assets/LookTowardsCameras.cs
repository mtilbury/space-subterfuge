using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardsCameras : MonoBehaviour
{
    public Transform farAway;

    // Start is called before the first frame update
    void Start()
    {
        farAway.position = farAway.position + new Vector3(0, -20, 15);
        transform.LookAt(farAway);
    }

}
