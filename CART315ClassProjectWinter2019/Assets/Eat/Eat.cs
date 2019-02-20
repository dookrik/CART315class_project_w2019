using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*====================================================================================
EAT Script
by
Ebrahim Badawi, Martin-John Hearty, Catherine Weng

Description:
Player can eat the items it pickes up, which have "Eatable" script attached to them, 
by Pressing "E" on keyboard!
while eatenig, the food decreases in size and when it's finished, player drops its leftovers. 


====================================================================================*/

public class Eat : MonoBehaviour
{
    public float speed = 2f;
    public float duration = 5f;
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
                    Eatable eatable = child.GetComponent<Eatable>();
                    if (child.gameObject != null && eatable != null)
                    {
                        //If the variables are public, we can do this:

                        //myFood.isHolding = false;
                        //myFood.buttonDown = false; 
                        //myFood.pickup = null;

                        // if No, I've created a function inside of Pickupper2 Script
                       
                        Vector3 foodSize = child.gameObject.transform.localScale;                    
                        StartCoroutine(EatTheShit(child, foodSize, duration));           

                    }
                }    
            }
        }
    }


   public IEnumerator EatTheShit(Transform _shit, Vector3 _foodSize, float _time)
   {
        float i = 0.0f;
        float eatingRate = (1.0f / _time) * speed;

        while (i <= 1.0f)
        {
            i += Time.deltaTime * eatingRate;
            _shit.transform.localScale = Vector3.Lerp(_foodSize, _foodSize / 2, i);   
            yield return null;
        }
        if (i >= 1.0f)
        {
            yield return StartCoroutine(FinishEating(_shit));
        }

   }


    public IEnumerator FinishEating(Transform _shit)
    {
        _shit.GetComponent<Rigidbody>().useGravity = true;
        _shit.parent = null;
        myFood.DigestTheFood();
        Destroy(_shit.gameObject, duration/3);
        yield return null;
    }
   
}
