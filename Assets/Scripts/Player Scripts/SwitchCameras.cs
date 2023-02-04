// This script is used to switch between two cameras in a Unity scene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{   
    //Create an instance of this script to be accessed by other objects
    public static SwitchCameras instance; 
    
    [Space(10)] // Space between titles.
    [Header("Cameras's GameObject")] // Title Inspector
    public GameObject playerWalkCamera;
    public GameObject playerSitCamera;
    
    [Space(10)]
    [Header("GameObject3D")]
    public GameObject pcMonitor;

    [Space(10)]
    [Header("Canvas's GameObject")]
    public GameObject referencePoints;

    private void Awake() {
        // Assign the instance to this script
        instance = this;
    }

    void Update() {
        if (playerSitCamera.activeInHierarchy) {
            ChangeToWalkVision();
        }
    }

    // This function check if the walk camera is diabled and if the mouse is pressed, then change to sit vision
    public void ChangeToSitVision() {
        if (!playerSitCamera.activeInHierarchy && Input.GetMouseButtonDown(0)) {
            
            // Activating SitCamera and Pc's box collider
            playerSitCamera.SetActive(true);
            pcMonitor.GetComponent<BoxCollider>().enabled = true;
            
            // Deactivating WalkCamera, reference points.
            playerWalkCamera.SetActive(false);
            referencePoints.SetActive(false);
        }
    }

    // This function check if sit camera is disabled and if the mouse is pressed, then change to walk vision
    public void ChangeToWalkVision() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            
            // Activating WalkCamera, reference points and cursor.
            playerWalkCamera.SetActive(true);
            referencePoints.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            // Deactivating SitCamera and Pc's box collider
            playerSitCamera.SetActive(false);
            pcMonitor.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
