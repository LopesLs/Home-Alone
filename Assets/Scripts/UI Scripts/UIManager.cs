// This script handles the UI elements in the game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Singleton Instance
    public static UIManager instance;
    public GameObject cursorImage;

    // This function set the instance to the current object
    private void Awake() {
        instance = this;        
    }

    // This function Enable/Disable the cursor
    public void ActiveCursor(bool state) {
        cursorImage.SetActive(state);        
    }
}
