// This script is used for player movement in the game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{   
    // Variables for horizontal and vertical input axis names
    [SerializeField] private string horizontalInputName = "Horizontal";
    [SerializeField] private string verticalInputName = "Vertical";

    // Variable for movement speed
    [SerializeField] private float movementSpeed = 1.5f;
    
    // Reference to character controller component
    private CharacterController charController;

    // Get reference to character controller component on awake
    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update player movement in each frame
    private void Update()
    {
        PlayerMovement();
    }

    // Function for player movement
    private void PlayerMovement()
    {
        
        // Check if left shift key is pressed for sprinting
        if (Input.GetKey(KeyCode.LeftShift)) {
            
            // Increase movement speed
            movementSpeed = 3f;
        }
        
        // If left shift is not pressed, set movement speed back to normal        
        else {
            movementSpeed = 1.5f;
        }

        // Get input for vertical and horizontal movement
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

        // Create vectors for forward and right movement based on vertical and horizontal inputs
        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        // Move the character controller based on forward and right movement vectors
        charController.SimpleMove(forwardMovement + rightMovement);
    }
}
