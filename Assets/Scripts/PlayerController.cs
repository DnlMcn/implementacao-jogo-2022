using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerTransform;

    Vector3 movement;
    public float movementSpeed;
    public float jumpHeight;

    Vector3 GetMovement()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement = movement.x * playerTransform.right + movement.z * playerTransform.forward;
        return movement;
    }

    void Update()
    {
        controller.Move(GetMovement() * movementSpeed * Time.deltaTime);


    }
}
