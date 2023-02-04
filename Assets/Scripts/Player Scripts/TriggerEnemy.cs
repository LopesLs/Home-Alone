// This script is used to activate the enemy's movement
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    private bool root;

    // Update is called once per frame
    void Update() {
        
        // If root is true, start the enemy's movement.
        if (root) {
            Enemy.instance.Run();
        }
    }
    
    // Function that is called when the enemy's trigger collides with another collider.
    private void OnTriggerEnter(Collider other) {
        
        // Grant acess to run movement case the collider's tag equals "Trigger".
        switch (other.gameObject.tag) {
            case "Trigger":
                root = true;
                break;
        }
    }
    
    // Function that will destroy the trigger, when we don't have more collision.
    private void OntriggerExit(Collider other) {
        Destroy(other.gameObject);
    }
}
