using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime,0,0);
    }
}
