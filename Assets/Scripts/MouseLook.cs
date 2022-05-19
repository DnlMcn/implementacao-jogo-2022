using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;

    public float mouseSensitivity;
    float xRotation = 0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks cursor to the center of the screen at start
    }
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;                                           
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // Vertical rotation

        playerBody.Rotate(Vector3.up * mouseX); // Horizontal rotation (applied to the player body)

    }
}
