using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTest : MonoBehaviour
{
    Throw thrower;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        thrower = GetComponent<Throw>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Throw"))
        {
            thrower.ThrowObject(target);
        }
    }
}
