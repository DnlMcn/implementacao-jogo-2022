using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform transform;

    Vector3 movement;

    public float movementSpeed;


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        movement = transform.right * x + transform.forward * z;

        controller.Move(movement * movementSpeed * Time.deltaTime);   

    }
}
