using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 0;
    public float jumpPower = 0;
    public bool test = true;
    public Gamepad controller;

    private Rigidbody rb;
    Vector3 movementInput;
    //private bool jumpPressed = false;
    //private bool grounded = true;
    //private Camera viewCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10f)
        {
            SceneManager.LoadScene(0);
        }

        // If no gamepad is connected
        if (controller == null)
        {
            //Debug.Log("player is offline");
            return;
        }

        // Get movementInput
        Vector3 movementInput = new Vector3(controller.leftStick.x.ReadValue(), 0, controller.leftStick.y.ReadValue());

        // Update Player velocity
        rb.velocity = movementInput * playerSpeed;

        // Rotate Player
        if (movementInput != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movementInput);
        }
    }

    private void OnMove(InputValue value)
    {
        Debug.Log("moving");
        movementInput = value.Get<Vector3>();
    }
}
