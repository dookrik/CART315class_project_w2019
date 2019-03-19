using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyController : MonoBehaviour
{
    //following ironequals tut for reference -- https://medium.com/ironequal/unity-character-controller-vs-rigidbody-a1e243591483

    public Rigidbody characterBod;
    public float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        characterBod = GetComponent<Rigidbody>();
    }

    public void Locomote(Vector3 direction)
    {
        direction.y = 0;
        direction = direction.normalized;

        characterBod.AddForce(direction*speed*10, ForceMode.Force);
    }

    public void FixedUpdate()
    {
        if (characterBod.velocity.magnitude > 0.001f)
        {
           // Debug.Log(characterBod.velocity.magnitude);
            characterBod.transform.rotation = 
            Quaternion.RotateTowards(characterBod.transform.rotation, Quaternion.LookRotation(characterBod.velocity, Vector3.up), 10f);
        }
    }


}
