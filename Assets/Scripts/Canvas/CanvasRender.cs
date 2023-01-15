// This script is used for change the render and rectTransform of canvas object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityLibrary
{
    public class CanvasRender : MonoBehaviour
    {
        // Declare a public variable for the canvas object
        public Canvas canvas;
        
        // Declare a boolean to track if the mouse is inside the canvas object
        bool mouseInside;

        void Start()
        {
            // Initialize mouseInside as false
            mouseInside = false;
            
            // Get the canvas component and assign it to the canvas variable
            canvas = GetComponent<Canvas>();
        }

        void Update()
        {
            
            // Check if the left mouse button is pressed and the mouse is inside the canvas
            if (Input.GetMouseButtonDown(0) && mouseInside == true)
            {   
                canvas = GetComponent<Canvas>();
                
                // Change the render mode to ScreenSpaceOverlay
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }
            
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                canvas = GetComponent<Canvas>();
                
                // Change the render mode to WorldSpace
                canvas.renderMode = RenderMode.WorldSpace;
                
                // Call the ChangeTransform function
                ChangeTransform();
            }
        }

        // Function called when the mouse enters the canvas object
        void OnMouseEnter()
        {
            mouseInside = true;
        }

        // Function called when the mouse exits the canvas object
        void OnMouseExit()
        {
            mouseInside = false;
        }

        // Function to change the transform of the canvas object
        void ChangeTransform ()
        {   
            canvas = GetComponent<Canvas>();
            RectTransform rectTransform = canvas.GetComponent<RectTransform>();

            // Change the local position of the rect transform
            rectTransform.localPosition = new Vector3(2.776f, 1.666f, -3.7f);
            
            // Change the size delta of the rect transform
            rectTransform.sizeDelta = new Vector2(10.54f, 5.9f);
            
            // Change the local rotation of the rect transform
            rectTransform.localRotation = Quaternion.Euler(0f, 2.144f, 0f);
            
            // Change the local scale of the rect transform
            rectTransform.localScale = new Vector3(0.09691782f,0.09691782f, 0.09691782f);
        }
    }
}