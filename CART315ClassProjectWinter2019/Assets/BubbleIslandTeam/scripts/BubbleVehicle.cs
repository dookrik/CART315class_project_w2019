using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleVehicle : MonoBehaviour
{
    private Camera Cam;
    public List<GameObject> Children;

    // Start is called before the first frame update
    void Start()
    {
        Cam = GameObject.Find("Camera_Become").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Cam == null)
        {
            Cam = GameObject.Find("Camera_Become").GetComponent<Camera>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player")))
        {
            print("pop bubble");

            foreach (Transform child in transform)
            {
                if (child.tag == "Player")
                {
                    Children.Add(child.gameObject);
                    child.transform.parent = null;
                }
            }
            GameObject.Find("Camera_Become").transform.parent = Children[0].transform;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Inside bubble");
            Cam.gameObject.transform.parent.parent = gameObject.transform;
            if(Cam.gameObject.GetComponent<Become>().GetCamMode() == 1)
            {
                Cam.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            }
            else
            {
                Cam.gameObject.transform.localPosition = new Vector3(0, 1, -1);
            }
            Cam.gameObject.transform.parent = gameObject.transform;
            foreach (Transform child in transform)
            {
                if (child.tag == "Player")
                {
                    child.transform.localPosition = new Vector3(0, child.transform.localPosition.y, 0);
                }
            }
        }

    }


}
