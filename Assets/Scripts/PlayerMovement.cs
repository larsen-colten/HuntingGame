using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    // Speed
    public float baseSpeed = 12f;
    public float sprintSpeed = 10f;
    public float currentSpeed;
    public float gravity = -9.81f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 2f;
    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Check isGrounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = baseSpeed + sprintSpeed;
        }
        else
        {
            currentSpeed = baseSpeed;
        }

        // Movement
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
