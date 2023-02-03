// This script is used to switch between two cameras in a Unity scene

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    //Create an instance of this script to be accessed by other objects
    public static SwitchCameras instance;
    public Camera oldCam;
    public Camera newCam;
    public GameObject pcMonitor;
    public GameObject referencePoints;

    private void Awake() {
        // Assign the instance to this script
        instance = this;
    }

    // This function check if the mouse is pressed, then change the cameras
    public void ChangeToSitVision() {
        if (Input.GetMouseButtonDown(0)) {
            oldCam.depth = 0;
            oldCam.GetComponent<AudioListener>().enabled = false;
            newCam.depth = 1;
            newCam.GetComponent<AudioListener>().enabled = true;
            pcMonitor.GetComponent<BoxCollider>().enabled = true;
            referencePoints.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
