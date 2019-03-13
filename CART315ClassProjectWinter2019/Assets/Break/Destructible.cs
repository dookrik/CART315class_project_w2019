// CREDITS //
// Tutorial from which I learned this code: https://www.youtube.com/watch?v=EgNV0PWVaS8
// Assets by Doug Allen downloaded from here: http://devassets.com/assets/western-props-pack/


// CODE SUMMARY: This is a test code that lets the user click on an object to destroy it.
// There are two versions of each model (one broken, one unbroken). 
// The unbroken one is replaced by the broken one at the moment the user clicks on it, creating the illusion that the model is breaking.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    // Variable to refer to the destroyed version of the object
    public GameObject destroyedVersion;

    // Function to run when mouse is clicked.
    void OnMouseDown()
    {
        // Spawn the broken version with "instantiate", give it the same position and rotation as the original.
        Instantiate(destroyedVersion, transform.position, transform.rotation);

        // Destroy the unbroken version, lowercase gameObject refers to the current object.
        Destroy(gameObject);

    }
}


// FURTHER INSTRUCTIONS:
// the public variable GameObject --> destroyedVersion will appear in the inspector
// drag the broken version into the destroyedVersion field.