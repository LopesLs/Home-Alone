// This script handles player interaction with interactable objects in the game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Camera actualCam;
    public float rayDistance = 2;

    void Start() {
        // Assigns the main camera to the actualCam variable
        actualCam = Camera.main;   
    }

    void Update() {
        CheckInterectables();
    }

    // Function to check for interactable objects in front of the player
    void CheckInterectables() {
        RaycastHit hit;
        Vector3 rayOrigin = actualCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

        // If the raycast hits something
        if (Physics.Raycast(rayOrigin, actualCam.transform.forward, out hit, rayDistance)) {
            // Get the interactable script from the hit object
            Interectables interectable = hit.collider.GetComponent<Interectables>();

            // If the object has the interactable script
            if (interectable != null) {
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
