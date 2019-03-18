using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionController : MonoBehaviour
{
    //IN general, we are borrowing how we structure the code from ThirdPersonCharacter.cs from the standards assets :^ )
    //We also looked at the code for CharacterController.Move() in the Unity Documentation

    //these variables we want accessible in the unity editor
    public float speed = 3.0f;
    float jumpVelocity = 0f;
    public float maxJumpVel = 4f;
    public float jumpAccel = 2f;
    public float gravity = 2f;


    //necessary components to locomote
    public CharacterController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        //this allows us to access the CharacterController component on current object
        controller = GetComponent<CharacterController>();
    }

    public void Locomote(Vector3 moveDirection, bool jump)
    {
        //transforming from world to local
        moveDirection = transform.InverseTransformDirection(moveDirection.normalized);

        //are we ready to jump?
        if (jump && controller.isGrounded)
        {
            moveDirection.y = maxJumpVel;

            //Below is attempts at making jump smooth~
            //controller.transform.position = Vector3.Lerp(controller.transform.position, new Vector3 (moveDirection.x, 0f, moveDirection.z), Time.time);
            /*if (controller.velocity.y < maxJumpVel)
            {
                jumpVelocity = jumpVelocity + (jumpAccel * Time.deltaTime);
            }
            if (controller.velocity.y > maxJumpVel)
            {
                jump = false;
            }
     
            moveDirection.y = jumpVelocity;*/
        }

        moveDirection.y -= (gravity * Time.deltaTime);
        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}
