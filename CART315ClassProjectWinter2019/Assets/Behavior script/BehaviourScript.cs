using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//CURRENTLY WIP & has not been tested on unity
// CURRENT ISSUES:  does not activate ALL desired action script
//TO DO: ensure that it correctly calls and uses navmesh script to move to target, does desired action upon arriving & CHECKS WHEN ARRIVED.
public class BehaviourScript : MonoBehaviour
{
    public float action_distance;
    //navmesh script
    private NavMeshController Navigate;
    //pickup script
    public Pickupper2 ActionPickup;

    //Use script
    //public Useable ActionUse;

    //break script
   // public Break ActionBreak;

    //eat script
    //public Eat ActionEat;

    //combust script
    //public Combust ActionCombust;

    private GameObject User;
    public float Radius = 0f;
    public GameObject Target;
    public NewBehaviourScript Action;

    private bool inRange;
    private bool hasArrived = false;
    private GameObject WhatToTarget;
    private GameObject CollisionTest;
    private List<GameObject> objects = new List<GameObject>();
    private NewBehaviourScript DesiredAction;
    public Vector3 NewDirection;
    // Use this for initialization
    void Start()
    {
        Navigate = this.GetComponent<NavMeshController>();
        User = this.gameObject;
        DesiredAction = Action;
        User.AddComponent<SphereCollider>();
        User.GetComponent<SphereCollider>().isTrigger = true;
        User.GetComponent<SphereCollider>().radius = Radius;
        Debug.Log("Collider made");
    }
    // When the baehavior and targetting script is called, the script should be fed the desired tergetting radius and the gameobject that should be targeted within that radius
    void BehaviorSetup(){
        DesiredAction = Action;
    User.AddComponent<SphereCollider>();
        User.GetComponent<SphereCollider>().radius = Radius;
        Debug.Log("Collider made");

 }
 
 void HasArrivedAtTarget(){
 hasArrived= true;
 //this is where the desired action gets called once navmesh has brought it to its target
 
 
 
 }
    //add objects that fulfill the target type to a list when they enter the radius
    private void OnTriggerEnter(Collider other)
    {
        /* if(Test.gameObject = CollisionTest)
         {
             Debug.Log("Object found");

         }
         */       
         Debug.Log("Object found");
         if (other.gameObject == Target)
         {
             objects.Add(other.gameObject);
             Debug.Log("Target found");
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
                 Debug.Log("Nothing found");
             }
         }
     }
     // Update is called once per frame
     void FixedUpdate()
     {
         Debug.Log("Update firing");
         Debug.Log(objects.Count);
         DesiredAction = Action;
        //finds the closest object of the target type
        if (objects.Count > 0)
        {
            Debug.Log("Polling objects");
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
                    Debug.Log("Target has fired");
                }
            }

            Debug.Log("loop broken");
            Debug.Log(WhatToTarget.transform.position);

            inRange = true;
            //here is where i call the navmesh script using obj.transform as the destination  
            //hopefully the navmesh script gets called properly, and accepts the .position
            NewDirection = (WhatToTarget.transform.position);
            Navigate.NavMeshProvider(NewDirection); 
            //Navigate.NavMeshProvider(WhatToTarget.transform.position);
            Debug.Log("Navmesh has fired");

            if (this.action_distance > Vector3.Distance(this.transform.position, NewDirection))
            {
                Debug.Log("arrived");
                ActionPickup.PickUp();
            }

            //There needs to be a check for when the navmesh has finished before calling the desired action script

            /*
             //otherGameObject.GetComponent("OtherScript").DoSomething();
             //Conditional arguements for different actions, must fit the different call limitations of the action scripts
             if(DesiredAction == Pickupper2){
             //issue: calling pickup requires a button to be pressed, and does not specify what to pick up in the function
             ActionPickup.PickUp();
             }
             if(DesiredAction == Usable){
             //as per documentation, this should use the targeted object and not destroy it afterwards
             ActionUse.Use(WhatToTarget, false);
             }

             if(DesiredAction == Break){
             //this should destroy the target object. Presupposes that the object being targetted with the purpose of breaking has the script attached
             //ideally should simply call the break function on the targeted object
             //ActionBreak.WhatToTarget.explode();
             WhatToTarget.GetComponent<"Break">.explode();
             }

             if(DesiredAction == Combust){
             //should burn the targeted object: may need to specify the gameObject WhatToTarget
             //ActionCombust.Burn();
             WhatToTarget.GetComponent<"Combust">.Burn();
             }
             if(DesiredAction == Eat){
             //should eat the targeted WhatToTarget
             ActionEat.Eat();
             }
            */
        }
    }
}
