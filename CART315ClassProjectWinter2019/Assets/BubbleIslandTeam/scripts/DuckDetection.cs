using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckDetection : MonoBehaviour
{

    public Vector3 initialDuckPos;

    private void Start()
    {
        initialDuckPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "ActivePlayer")
        {
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(initialDuckPos, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), 0.5f);
        }
    }
}
