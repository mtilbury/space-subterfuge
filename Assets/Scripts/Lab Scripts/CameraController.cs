using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public float distanceFraction = 0.05f;

    public Vector3 offset;
    private Vector3 startingPosition;

    private bool lerping = true;

    private void Start()
    {
        startingPosition = new Vector3(player.transform.position.x, offset.y, player.transform.position.z + offset.z);
        Debug.Log(player.transform.position.z + offset.z);
    }

    private void Update()
    {
        if (lerping)
        {
            transform.position = Vector3.Lerp(transform.position, startingPosition, distanceFraction);
            Debug.Log("I am Lerping");
        }

        if (transform.position.y <= offset.y + .5 && transform.position.z <= offset.z + .5)
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
}
