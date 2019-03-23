using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyController : MonoBehaviour
{
    //following ironequals tut for reference -- https://medium.com/ironequal/unity-character-controller-vs-rigidbody-a1e243591483 and https://docs.huihoo.com/unity/3.3/Documentation/ScriptReference/Input.GetAxis.html

    private Rigidbody characterBod;
    public float speed = 2f;

    private Vector3 movementdirection;
    bool rotating = false;

    private float rotateXAxis = 0.0f;
    private float rotateYAxis = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        characterBod = GetComponent<Rigidbody>();
        rotateXAxis = characterBod.transform.eulerAngles.x;
        rotateYAxis = characterBod.transform.eulerAngles.y;
    }

    public void Locomote(Vector3 direction)
    {
        direction.y = 0;

        if (direction.magnitude > 0.01f)
        {
            rotating = true;
        }
        else
        {
            rotating = false;
        }

        direction = direction.normalized;
      
        direction.z *= speed * Time.deltaTime;
        direction.x *= speed * Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(direction.x, 0, direction.z);
        // Rotate around our y-axis
        transform.Rotate(0, direction.x, 0);

        movementdirection = direction;
    }
    public void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            rotateYAxis += 3 * Input.GetAxis("Mouse X");
            rotateXAxis += 3 * Input.GetAxis("Mouse Y");

            rotating = true;
            characterBod.transform.eulerAngles = new Vector3(rotateXAxis, rotateYAxis, 0);
        }
        else
        {
            rotating = false;
            characterBod.transform.eulerAngles = new Vector3(rotateXAxis, rotateYAxis, 0);
        }
    }

    public void FixedUpdate()
    {
        if (rotating)
        {
            // Debug.Log(characterBod.velocity.magnitude);
            characterBod.transform.rotation =
            Quaternion.RotateTowards(characterBod.transform.rotation, Quaternion.LookRotation(movementdirection, Vector3.up), 10f);
        }
    }


}
