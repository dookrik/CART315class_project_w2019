using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Become : MonoBehaviour
{
    private Camera fpsCam;
    private Ray ray;
    public float clickRange = 100f;

    void Start()
    {
        fpsCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray rayEnd = fpsCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayEnd, out hit, clickRange) && hit.collider.gameObject.GetComponent<CharacterController>() != null)
            {
                Become clickedObject = Instantiate(this, hit.collider.gameObject.transform.position, Quaternion.identity);
                clickedObject.gameObject.name = "Camera_Become";
                clickedObject.transform.SetParent(hit.collider.gameObject.transform);
                clickedObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                Destroy(gameObject);
            }
        }

    }

}
