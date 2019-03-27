using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatability : MonoBehaviour
{

    public Vector3 upLift = new Vector3(0, 14, 0);
    public Rigidbody rb;
    public float viscosity = 1f;
    public float drag = 1.5f;

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

        rb.velocity = new Vector3(5, 0, 0);

        colliderSize = collider.size;
        print(collider.center);
        defaultCenter = collider.center;

        firstLocalPoint = new Vector3(-colliderSize.x / 2, 0, 0);
        secondLocalPoint = new Vector3(0, 0, -colliderSize.x / 2);
        thirdLocalPoint = new Vector3(colliderSize.x / 2, 0, 0);
        fourthLocalPoint = new Vector3(0, 0, colliderSize.x / 2);

        Vector3 waterPosition = GameObject.Find("water").transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        int n = 0;
        firstWorldPoint = transform.TransformPoint(firstLocalPoint);
        secondWorldPoint = transform.TransformPoint(secondLocalPoint);
        thirdLocalPoint = transform.TransformPoint(thirdLocalPoint);
        fourthLocalPoint = transform.TransformPoint(fourthLocalPoint);

        if (transform.position.y <= waterPosition.y)
        {
            isSubmerged = true;
            //print("x");
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
            //print(collider.center);

            rb.AddForce((rb.velocity * -drag * viscosity) + upLift);
            //print(rb.velocity);
            collider.center = defaultCenter;
        }
        else isSubmerged = false;
        //      print ("velocity: " + rb.velocity);
        //      print ("position: " + transform.localPosition);
    }

    private void OnCollisionStay(Collision collision)
    {
        //print(collision.Layer);
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            rb.AddForce((rb.velocity * -drag * viscosity) + upLift);
        }
    }
}


