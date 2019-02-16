using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{


    //Check if IsHoldingObject()
    //Check held object HeldObject()
    //button fire and apply force Pickupper.Button Check
    //

    Pickupper pickupper = new Pickupper();
    GameObject heldObject;
    private bool toss;

    // Start is called before the first frame update
    void Start()
    {
        pickupper = GetComponent<Pickupper>();
    }

    // Update is called once per frame
    void Update()
    {

        if (pickupper.IsHoldingObject())
        {
            heldObject = pickupper.HeldObject();
            if (Input.GetButtonDown("Throw")){
                pickupper.ButtonCheck();
                //apply force here
                print("throw");
                heldObject = null;
            }
        }
        else
        {
            heldObject = null;
        }

        
    }


}
