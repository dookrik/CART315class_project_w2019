using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    private Pickupper2 myFood;
    Transform foodLoc;

    void FixedUpdate()
    {
        
        myFood = GameObject.Find("Player").GetComponent<Pickupper2>();

        if (myFood.IsHoldingObject()) {
            
            foodLoc = myFood.grabPoint;

            if (Input.GetButtonDown("Eat"))
            {
               

                foreach (Transform child in foodLoc)
                {
                    if (child.gameObject != null)
                    {
                        //If the variables are public, we can do this:

                        //myFood.isHolding = false;
                        //myFood.buttonDown = false; 
                        //myFood.pickup = null;

                        // if No, I've created a function inside of Pickupper2 Script

                        myFood.EatIt();
                        Destroy(child.gameObject);
                        CreateCube();
                    }
                }

                

                //Instantiate(food, foodLoc.position, Quaternion.identity);

                //Debug.Log("fucked");
            }
        }
    }

    private void CreateCube()
    {
        GameObject food;
        food = GameObject.CreatePrimitive(PrimitiveType.Cube);

        food.transform.localScale = foodLoc.localScale / 3;
        food.transform.position = foodLoc.position;
        food.AddComponent<Rigidbody>();
        Destroy(food.gameObject, 2f);
    }
}
