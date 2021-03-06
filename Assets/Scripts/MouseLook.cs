using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1000f;
    public Transform playerBody;

    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Lock mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Grab mouse inputs
        float mouseX = Input.GetAxis("Mouse X") *  mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") *  mouseSensitivity * Time.deltaTime;

        // Mouse rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Player mouse movment
        playerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


    }
}
