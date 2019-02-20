using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseController : MonoBehaviour
{
    //Must have the pickupper script attached to the object in order for it to work

    private Pickupper PickUp;
    // Start is called before the first frame update
    void Start()
    {
        PickUp = GetComponent<Pickupper>();
    }

    // Update is called once per frame
    void Update()
    {
        //use button is E 
        if (Input.GetButtonDown("Use"))
        {
            if (PickUp.IsHoldingObject())
            {
                Usable usable = PickUp.HeldObject().GetComponent<Usable>();
                if (usable != null)
                {
                    usable.Use();
                    Debug.Log("use Pressed");

                }
            }
        }
    }

    public void TestUse(GameObject obj)
    {
        Destroy(obj);
    }
}
