using UnityEngine;
using System.Collections;
//CURRENTLY WIP & has not been tested on unity
// CURRENT ISSUES: does not call navmesh script, does not activate desired action script
//TO DO: ensure that it correctly calls and uses navmesh script to move to target, does desired action upon arriving
public class Behaviour : MonoBehaviour
{
    private bool inRange;
    private GameObject WhatToTarget;
    private List<GameObject> objects = new List<GameObject>();
    private script DesiredAction;
    // Use this for initialization
    void Start()
    {

    }
    // When the baehavior and targetting script is called, the script should be fed the desired tergetting radius and the gameobject that should be targeted within that radius
    void BehaviorSetup(GameObject User, float Radius, GameObject Target, script Action ){
        DesiredAction = Action;
    User.AddComponent<SphereCollider>() as SphereCollider;
        User.GetComponent<SphereCollider>.radius = Radius;
        //finds the closest object of the target type
        if (objects.Count >= 1 )
        {
            Vector3 currentPosition = this.transform.position;
            float nearestDist = Mathf.Infinity;

            foreach (GameObject obj in objects)
            {
                Vector3 dist = obj.transform.position - currentPosition;
                float distSqr = dist.sqrMagnitude;
                if (distSqr < nearestDist)
                {
                    nearestDist = distSqr;
                    WhatToTarget = obj;
                }
            }


            inRange = true;
            //here is where i call the navmesh script using obj.transform as the destination

        }
    }
    //add objects that fulfill the target type to a list when they enter the radius
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Target)
        {
            objects.Add(other.gameObject);
        }
    }
    //remove said objects from the list when they leave the radius
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Target)
        {
            objects.Remove(other.gameObject);
            if (objects.Count == 0)
            {

            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
