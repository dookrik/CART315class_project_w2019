using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyController : MonoBehaviour
{
    //following ironequals tut for reference -- https://medium.com/ironequal/unity-character-controller-vs-rigidbody-a1e243591483

    private Rigidbody characterBod;
    public float speed = 2f;

    private Vector3 movementdirection;
    bool rotating = false;


    // Start is called before the first frame update
    void Start()
    {
        characterBod = GetComponent<Rigidbody>();
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

        characterBod.AddForce(direction*speed*10, ForceMode.Force);

        movementdirection = direction;
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
