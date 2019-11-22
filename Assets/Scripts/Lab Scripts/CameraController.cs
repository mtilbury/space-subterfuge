using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public float distanceFraction = 0.05f;
    //public float distanceDelta = 

    public Vector3 offset;
    private Vector3 startingPosition;

    private bool lerping = true;

    private void Start()
    {
        startingPosition = player.transform.position + offset;
        Debug.Log(player.transform.position.z + offset.z);
    }

    private void Update()
    {
        if (lerping)
        {
            transform.position = Vector3.Lerp(transform.position, startingPosition, distanceFraction);
            Debug.Log("I am Lerping");
        }

        if (withinRange(transform.position.y, startingPosition.y, .1f) && withinRange(transform.position.z, startingPosition.z, .1f) && withinRange(transform.position.x, startingPosition.x, .1f))
        {
            lerping = false;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!lerping) 
            transform.position = player.transform.position + offset;
    }

    private bool withinRange(float a, float b, float delta)
    {
        return Mathf.Abs(Mathf.Abs(a) - Mathf.Abs(b)) <= delta;
    }
}
