using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyUser : MonoBehaviour
{
    private RigidBodyController charControl;

    // Start is called before the first frame update
    void Start()
    {
        charControl = GetComponent<RigidBodyController>();
    }

    // Update is called once per frame
    void Update()
    {
        charControl.Locomote(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }
}
