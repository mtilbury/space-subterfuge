using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoppingAnimation : MonoBehaviour
{
    public GameObject player;
    public float hopForce = 2.0f;
    public float frequency = 8.0f;
    public float offset = 0.5f;

    public float emptyGameObjectPosition = 1.95f;
    Vector3 movementInput;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void LateUpdate()
    {
        movementInput = player.GetComponent<PlayerMovement>().movementInput;
        if (movementInput != Vector3.zero)
        {
            transform.position = (Vector3.up * (Mathf.Abs(Mathf.Sin(Time.time * frequency)) + offset) * hopForce);

        }

        if (movementInput != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movementInput);
        }

        if (transform.position.y > emptyGameObjectPosition)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        }

        else
        {
            transform.position = new Vector3(player.transform.position.x, emptyGameObjectPosition, player.transform.position.z);
        }

    }

}
