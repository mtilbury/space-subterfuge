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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(transform.position.y < -10f)
        {
            SceneManager.LoadScene(0);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
    }


    private void FixedUpdate()
    {
        rb.AddForce(movement * speed);

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
