// This script is used for active/desactive the canvas in ScreenOverlay

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActive : MonoBehaviour
{   
    // public variable to reference the canvas object
    public GameObject canvas;
    
    // variable to track whether the mouse is inside the canvas
    bool mouseInside;

    void Start() {
        // initialize mouseInside as false
        mouseInside = false;
    }

    void Update() {
        // if the mouse is inside the canvas and the left mouse button is pressed, and the canvas is not active
        if (mouseInside == true && Input.GetMouseButtonDown(0) && canvas.activeInHierarchy == false) {
            
            // activate the canvas
            canvas.SetActive(true);
        }

        // if the Escape key is pressed and the canvas is active
        else if (Input.GetKeyDown(KeyCode.Escape) && canvas.activeInHierarchy == true) {
            
            // deactivate the canvas
            canvas.SetActive(false);
        };
    }

    // function called when the mouse enters the canvas
    void OnMouseEnter() {
        
        // set mouseInside to true
        mouseInside = true;
    }

    // function called when the mouse exits the canvas
    void OnMouseExit() {
        
        // set mouseInside to false
        mouseInside = false;
    }
}