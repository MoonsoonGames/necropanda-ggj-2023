using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 6.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Rotate player based on mouse movement
        transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);

        // Move player forward/backward
        moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // Move player left/right
        moveDirection.x = Input.GetAxis("Horizontal") * speed;

        // Jump
        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move character
        controller.Move(moveDirection * Time.deltaTime);
    }
}