using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpPower;


    private Rigidbody rb;
    Vector3 movement;
    private bool grounded = true;

    private Camera viewCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    private void Update()
    {
        if(transform.position.y < -10f)
        {
            SceneManager.LoadScene(0);
        }

        float moveHorizontal = 0.0f;
        float moveVertical = 0.0f;

        if (Input.GetKey(KeyCode.W))
            moveVertical = 1.0f;
        else if (Input.GetKey(KeyCode.S))
            moveVertical = -1.0f;

        if (Input.GetKey(KeyCode.A))
            moveHorizontal = -1.0f;
        else if (Input.GetKey(KeyCode.D))
            moveHorizontal = 1.0f;

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        /*
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            viewCamera.transform.position.y));
        transform.LookAt(mousePos + Vector3.up * transform.position.y);
        */
        
    }


    private void FixedUpdate()
    {
        rb.velocity = (movement * speed);
        if(movement != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(movement);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
            //rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

    }


    private void OnCollisionStay(Collision collision)
    {
            Debug.Log("Reset");
            grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
            grounded = false;
    }
}
