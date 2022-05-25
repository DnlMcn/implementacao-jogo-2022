using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerTransform;
    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 movement;
    public float movementSpeed;
    float jumpHeight = 2.5f;
    float gravity = 12f;
    bool isGrounded;
    float groundCheckDistance;

    Vector3 GetMovement()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 1, Input.GetAxis("Vertical"));
        movement = movement.x * playerTransform.right + movement.z * playerTransform.forward;
        return movement;
    }

    void Update()
    {
        movement = GetMovement();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded) { movement.y = Mathf.Sqrt(jumpHeight * -2 * gravity); }

        controller.Move(Vector3.up * movement.y);

        if (isGrounded && movement.y < 0) { movement.y = -1; }

        controller.Move(movement * movementSpeed * Time.deltaTime);
    }
}
