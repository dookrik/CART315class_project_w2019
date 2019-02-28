using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionController : MonoBehaviour
{
    //IN general, we are borrowing how we structure the code from ThirdPersonCharacter.cs from the standards assets :^ )
    //We also looked at the code for CharacterController.Move() in the Unity Documentation

    //these variables we want accessible in the unity editor
    public float speed = 3.0f;
    public float maxJumpVel = 4f;
    public float jumpAccel = 10f;
    public float gravity = 25f;

    private bool isGrounded = true;

    private Vector3 moveDirection = Vector3.zero;

    //necessary components to locomote
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        //this allows us to access the CharacterController component on current object
        controller = GetComponent<CharacterController>();
        gameObject.transform.position = new Vector3(0, 2, 0); //dropping a bit just to spawn in
    }
    void Update()
    {
        if (controller.isGrounded)
        {     
    
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;
            if (Input.GetButton("Run")) moveDirection *= 2.5f;


            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpAccel;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}  
 

    

