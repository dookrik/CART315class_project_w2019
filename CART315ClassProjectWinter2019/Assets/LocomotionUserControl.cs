using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionUserControl : MonoBehaviour
{
    private LocomotionController playerBody; //reference to the object currently in players control
    private Vector3 direction;              
    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<LocomotionController>();
    }

    // Update is called once per frame
    void Update()
    {
        //jumping is handled in regular update so it's responsive!
        if (!jump)
        {
            //mapped to space and joystick button 14
            jump = Input.GetButton("Jump");
        }

    }


    private void FixedUpdate()
    {
        //more physics based things? let's do at a consistent fps.
        //inputs~!!
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //running, mapped to left shift and joystick button 15
        if (Input.GetButton("Run")) direction *= 2.5f;

        // pass all parameters to the character control script
        playerBody.Locomote(direction, jump);
        if (playerBody.controller.isGrounded)
        {
            jump = false;
        }
    }
}
