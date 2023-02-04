// This script handles player interaction with interactable objects in the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{   
    [Space(5)]
    [Header("Raycast Light")]
    [Range(1, 10)]
    public float distance = 1;

    [Space(5)]
    [Header("Actual Camera")]
    public Camera myCamera;

    [Space(5)]
    [Header("Interectable Tag")]
    public new string name = "Interactable";

    // Start is called before the first frame update
    void Start() {
        // Assigns the main camera to the actualCam variable
        myCamera = Camera.main;   
    }
    
    // Update is called once per frame
    void Update() {
        CheckInterectables();
    }

    // Function to check for interactable objects in front of the player
    void CheckInterectables() {
        RaycastHit hitPoint;
        Vector3 rayOrigin = myCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

        // If the raycast hits something
        if (Physics.Raycast(rayOrigin, myCamera.transform.forward, out hitPoint, distance)) {
            
            // If the collider have the Interectable tag
            if (hitPoint.collider.tag == name) {
                UIManager.instance.ActiveCursor(true);
                SwitchCameras.instance.ChangeToSitVision();
            }

            // If the object does not have the interactable script
            else {
                UIManager.instance.ActiveCursor(false);
            }
        }

        // If the raycast does not hit anything
        else {
            UIManager.instance.ActiveCursor(false);
        }
    }
}
