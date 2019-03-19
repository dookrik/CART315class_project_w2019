using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTimer : MonoBehaviour
{
    //timer 
    private float timer;
    //destroyer at time
    public float destroyTime = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DestroyObj();
    }

    //function that destroys the particle effect
    public void DestroyObj()
    {
        //update the timer
        timer += Time.fixedDeltaTime;

        if (timer > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
