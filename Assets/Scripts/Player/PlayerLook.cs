// This script is used to configure the camera of player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // Input axes for mouse movement
    [SerializeField] private string mouseXInputName = "Mouse X";
    [SerializeField] private string mouseYInputName = "Mouse Y";
    
    // Sensitivity of the mouse movement
    [SerializeField] private float mouseSensitivity = 150f;

    // Reference to the player's body transform
    [SerializeField] private Transform playerBody;
    
    // Variable to store the clamp value for the X axis rotation
    private float xAxisClamp;
    
    // Flag to check if the cursor is locked
    private bool m_cursorIsLocked = true;

    private void Awake()
    {
        // Lock the cursor on start
        LockCursor();
        xAxisClamp = 0.0f;
    }

    private void LockCursor()
    {
        // Check if the F1 key is released and lock the cursor
        if (Input.GetKeyUp(KeyCode.F1))
        {
            m_cursorIsLocked = false;
        }
        // Check if the left mouse button is released and unlock the cursor
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }

        // Set the cursor lock state and visibility based on the flag
        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void Update()
    {
        // Call the camera rotation function
        CameraRotation();
    }

    private void CameraRotation()
    {
        // Get input for horizontal and vertical mouse movement
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        // Keep track of the current rotation on the x-axis
        xAxisClamp += mouseY;

        // Limit the rotation on the x-axis to prevent the camera from flipping
        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        // Rotate the camera on the y-axis
        transform.Rotate(Vector3.left * mouseY);
        
        // Rotate the player body on the x-axis
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        // Get the current rotation values
        Vector3 eulerRotation = transform.eulerAngles;
        
        // Set the x-axis rotation to the specified value
        eulerRotation.x = value;
        
        // Apply the new rotation values
        transform.eulerAngles = eulerRotation;
    }
}
