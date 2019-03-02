using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionUserControl : MonoBehaviour
{
    private LocomotionController playerBody; //reference to the object currently in players control
    private Vector3 direction;
    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<LocomotionController>();
    }
}
