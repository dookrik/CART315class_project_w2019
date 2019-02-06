using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Become : MonoBehaviour
{
    private Camera fpsCam;
    RaycastHit hit;
    private float clickRange = 100f;

    void Start()
    {
        fpsCam = GetComponent<Camera>();
    }
    //we want to update every frame to make sure no frames are skipped 
    void Update()
    {
        //if left click
        if (Input.GetMouseButtonDown(0))
        {
            //create a ray that is between the camera position and the positoin of the object the mouse clicked on
            Ray rayEnd = fpsCam.ScreenPointToRay(Input.mousePosition);

            //if the mouse clicks on the gameobject and that gameobject has a CharacterController as a component, meaning that object is a player
            if (Physics.Raycast(rayEnd, out hit, clickRange) && hit.collider.gameObject.GetComponent<CharacterController>() != null)
            {
                //instantiate a new camera at the position of the object that was clicked on
                Become clickedObject = Instantiate(this, hit.collider.gameObject.transform.position, Quaternion.identity);
                //change the name of that camera to avoid (clone) being added every single time
                clickedObject.gameObject.name = "Camera_Become";
                //make the camera a chid of the clicked game object to center its postion relative to the player
                clickedObject.transform.SetParent(hit.collider.gameObject.transform);
                clickedObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                //Destroy the old camera.
                Destroy(gameObject);
            }
        }
    }

}
