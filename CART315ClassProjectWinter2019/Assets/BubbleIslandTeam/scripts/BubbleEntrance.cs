using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEntrance : MonoBehaviour
{
    private Camera Cam;
    public GameObject MaskZone;
    public GameObject DomeMask;
    public GameObject title;
    RaycastHit hit;
    private int counter;

    private void Start()
    {
        Cam = GameObject.Find("Camera_Become").GetComponent<Camera>();
        title.SetActive(false);
        MaskZone.transform.localPosition = new Vector3(0,0,-(GetComponent<Renderer>().bounds.extents.x - (MaskZone.GetComponent<Renderer>().bounds.extents.z / 2)) + 0.4f);
        counter = 0;
    }


    private void FixedUpdate()
    {
        if(counter == 2)
        {
            StartCoroutine(Delay(1));
        }
        if (Cam == null)
        {
            Cam = GameObject.Find("Camera_Become").GetComponent<Camera>();
        }

    }

    IEnumerator Delay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //code executes after the waitTime is elapsed 
        MaskZone.transform.localScale = new Vector3(0, 0, 0);
        counter++;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Cam.transform.parent.gameObject)
        {
            counter++;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        MaskZone.transform.localScale = new Vector3(0, 0, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Cam.transform.parent.gameObject)
        {
            Debug.DrawRay(Cam.transform.parent.gameObject.transform.position, Cam.transform.parent.gameObject.transform.forward * 10, Color.red);

            if (Physics.Raycast(Cam.transform.parent.gameObject.transform.position, Cam.transform.parent.gameObject.transform.forward, out hit, 10.0f))
            {
                //print(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "DomeMaterial" || hit.collider.gameObject.name == "Dome")
                {
                    Vector3 localTarget = transform.InverseTransformPoint(Cam.transform.parent.gameObject.transform.position);

                    float y_angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
                    float x_angle = Mathf.Atan2(localTarget.y, localTarget.z) * Mathf.Rad2Deg;

                    y_angle += 180;
                    y_angle = (y_angle > 180) ? y_angle - 360 : y_angle;
                    x_angle += 180;
                    x_angle = (x_angle > 180) ? x_angle - 360 : x_angle;
                    DomeMask.transform.eulerAngles = new Vector3(-x_angle, y_angle, 0);

                    if (1 / hit.distance < 1)
                    {
                        OpenEntrance();
                    }
                }
            }
        }
    }

    private void OpenEntrance()
    {
        //print(1 / hit.distance);
        if (1 / hit.distance >= 0.2f)
        {
            title.SetActive(true);
        }
        else
        {
            title.SetActive(false);
        }

        float x = 0;
        float y = 0;
        float z = 0;

        if (x < 0.25 && y < 0.25 && z < 0.25)
        {
            x = (1 / hit.distance) * 5;
            y = (1 / hit.distance) * 5;
            z = (1 / hit.distance) * 5;
        }
        else
        {
            x = (1 / hit.distance) * 30;
            y = (1 / hit.distance) * 30;
            z = (1 / hit.distance) * 30;
        }

        if (x > 20 && z > 20)
        {
            x = 10;
            z = 10;
        }

        if (y > 0.25f)
        {
            y = 0.25f;
        }

        MaskZone.transform.localScale = new Vector3(x, y, z);
    }
}
