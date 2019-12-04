using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContinuousHop : MonoBehaviour
{
    public GameObject player;
    public float hopForce = 2.0f;
    public float frequency = 8.0f;
    public float offset = 0.5f;
    Vector3 movementInput;

    public Transform cam;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        Vector3 oldPos = transform.position;
        transform.position = (Vector3.up * (Mathf.Abs(Mathf.Sin(Time.time * frequency)) + offset) * hopForce);

        transform.position = new Vector3(oldPos.x, transform.position.y, oldPos.z);

    }

}
