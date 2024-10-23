using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // Reference to the player's Transform component for Y-axis rotation
    public Transform player;

    public float sensitivity = 200f;
    private float xRotation = 0f; // Tracks the camera's X-axis rotation

    void Start()
    {
        // Lock and hide the cursor in the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get the mouse movement input
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Rotate player around the Y-axis
        player.Rotate(Vector3.up * mouseXMove);

        // Adjust the xRotation by the mouse's Y movement
        xRotation -= mouseYMove;

        // Clamp the xRotation value to -90 and +90 degrees to limit vertical rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the clamped rotation to the camera around the X-axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
