using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDestroyer : MonoBehaviour
{

    //timer 
    private float timer;
    //destroyer at time
    private float destroyTime = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DestroyObj();
    }

    public void DestroyObj()
    {
        //update the timer
        timer += Time.fixedDeltaTime;

        if (timer > destroyTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on the cube");
        Destroy(gameObject);
    }
}
