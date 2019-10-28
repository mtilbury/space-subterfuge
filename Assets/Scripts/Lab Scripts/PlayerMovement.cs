using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 0;
    public float jumpPower = 0;

    private Rigidbody rb;
    Vector3 movementInput;
    private bool jumpPressed = false;
    private bool grounded = true;
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
        var gamepad = Gamepad.current;

        if (transform.position.y < -10f)
        {
            SceneManager.LoadScene(0);
        }

        // If no gamepad is connected
        if (gamepad == null)
            return;
        /*
        // Get jumpPressed input
        if (gamepad.aButton.wasPressedThisFrame && grounded)
        {
            jumpPressed = true;
        }
        */

        // Get movementInput
        Vector3 movementInput = new Vector3(gamepad.leftStick.x.ReadValue(), 0, gamepad.leftStick.y.ReadValue());

        // Update Player velocity
        rb.velocity = movementInput * playerSpeed;

        // Rotate Player
        if (movementInput != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movementInput);
        }

        /*
        if (jumpPressed && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.x);
            jumpPressed = false;
        }
        */
    }

    /*
    private void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
    */
}
