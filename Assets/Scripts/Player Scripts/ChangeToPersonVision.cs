// This script is used for change the camera to PersonVision

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToPersonVision : MonoBehaviour
{
    public static SwitchCameras instance;
    public Camera oldCam;
    public Camera newCam;
    public GameObject pcMonitor;
    public GameObject referencePoints;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            oldCam.depth = 0;
            oldCam.GetComponent<AudioListener>().enabled = false;
            newCam.depth = 1;
            newCam.GetComponent<AudioListener>().enabled = true;
            pcMonitor.GetComponent<BoxCollider>().enabled = false;
            referencePoints.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
