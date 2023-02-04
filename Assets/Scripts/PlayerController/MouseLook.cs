using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MattRobertsCGD.Player
{
    public class MouseLook : MonoBehaviour
    {
        public float mouseSensitivity = 100f;
        public Transform playerBody;
        public PlayerMovement playerMovement;

        float xRotation = 0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        // Update is called once per frame
        void Update()
        {
            if (playerMovement.paused)
            {
                return;
            }
            else
            {
                DoLook();
            }
        }

        void DoLook()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}