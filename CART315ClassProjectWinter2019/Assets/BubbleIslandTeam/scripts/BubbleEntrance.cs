using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEntrance : MonoBehaviour
{
    public Camera Cam;
    public GameObject MaskZone;
    RaycastHit hit;


    private void Start()
    {
        print((GetComponent<Renderer>().bounds.extents.x- (MaskZone.GetComponent<Renderer>().bounds.extents.z / 2))-0.2);

    }


    private void FixedUpdate()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        MaskZone.transform.localScale = new Vector3(0,0,5);
    }
    private void OnTriggerStay(Collider other)
    {
        Ray rayOrigin = Cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        Debug.DrawRay(rayOrigin.origin, rayOrigin.direction * 10, Color.red);

        if (Physics.Raycast(rayOrigin, out hit, 10.0f))
        {
            if (hit.collider.gameObject.name == "Dome")
            {
                //print(hit.distance);

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
               
                if (y > 0.35f)
                {
                    y = 0.35f;
                }
                if (hit.distance <= 0.15f)
                {
                    Cam.nearClipPlane = 0.8f;
                }
                else
                {
                    Cam.nearClipPlane = 0.2f;
                }

                MaskZone.transform.localScale = new Vector3(x, y, z);
            }
        }
    }
}
