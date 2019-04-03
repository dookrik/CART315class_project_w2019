using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buoyancy : MonoBehaviour
{

    public Vector3 upLift = new Vector3(0, 9.8f, 0);
    public Rigidbody rb;
    public float viscosity = 1f;
    public float drag = 1.5f;
    public Vector3 initialSpeed = new Vector3(0, 0, 0);
    public static bool isSubmerged = false;


    private Vector3 colliderSize, firstLocalPoint, secondLocalPoint, thirdLocalPoint, fourthLocalPoint,
    firstWorldPoint, secondWorldPoint, thirdWorldPoint, fourthWorldPoint, defaultCenter;

    BoxCollider collider;

    private Vector3 waterPosition;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();

        rb.velocity = initialSpeed;

        colliderSize = collider.size;
        defaultCenter = collider.center;

        /*
        firstLocalPoint = new Vector3(-colliderSize.x / 2, 0, colliderSize.z / 2);
        secondLocalPoint = new Vector3(-colliderSize.x / 2, 0, -colliderSize.z / 2);
        thirdLocalPoint = new Vector3(colliderSize.x / 2, 0, colliderSize.z / 2);
        fourthLocalPoint = new Vector3(colliderSize.x / 2, 0, -colliderSize.z / 2);
        */       

        Vector3 waterPosition = GameObject.Find("Plane").transform.position;

        collider.center = defaultCenter - new Vector3(0, colliderSize.y / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > waterPosition.y) isSubmerged = false;
        if (transform.position.y < waterPosition.y) isSubmerged = true;

        /*
        //if ever you wanted to redefine the buoyancy based on an uplift that is placed at an
        //approximation of the submerged center
        int n = 0;
        firstWorldPoint = transform.TransformPoint(firstLocalPoint);
        secondWorldPoint = transform.TransformPoint(secondLocalPoint);
        thirdLocalPoint = transform.TransformPoint(thirdLocalPoint);
        fourthLocalPoint = transform.TransformPoint(fourthLocalPoint);

        if (firstWorldPoint.y <= waterPosition.y)
        {
           collider.center += firstLocalPoint;
            n++;
        }
        if (secondWorldPoint.y <= waterPosition.y)
        {
            collider.center += secondLocalPoint;
            n++;
        }
        if (thirdWorldPoint.y <= waterPosition.y)
        {
           collider.center += thirdLocalPoint;
            n++;
        }
        if (fourthWorldPoint.y <= waterPosition.y)
        {
            collider.center += fourthLocalPoint;
            n++;
        }
        collider.center = collider.center / n;
        */

        //print(isSubmerged);
        if (isSubmerged)
        {
            rb.AddForce((rb.velocity * -drag * viscosity) + (upLift));

            //if you wanted to add the force at the approximated center
            //rb.AddForceAtPosition((rb.velocity * -drag * viscosity) + upLift, vollider.center);
        }

        //reset the center to default after each iteration
        //collider.center = defaultCenter;
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("collision");
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            isSubmerged = true;
            waterPosition = other.transform.position;
        }
    }
}


