using UnityEngine;
using System.Collections;
//CURRENTLY WIP & has not been tested on unity
// CURRENT ISSUES:  does not activate ALL desired action script
//TO DO: ensure that it correctly calls and uses navmesh script to move to target, does desired action upon arriving & CHECKS WHEN ARRIVED.
public class Behaviour : MonoBehaviour
{
    //navmesh script
    public NavMeshController Navigate;
    //pickup script
    public Pickupper ActionPickup;
    //Use script
    public Useable ActionUse;
    //break script
    public Break ActionBreak;
    //eat script
    public Eat ActionEat;
    //combust script
    public Combust ActionCombust;
    
    private bool inRange;
    private bool hasArrived = false;
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
            //hopefully the navmesh script gets called properly, and accepts the .position
            Navigate.NavMeshProvider(WhatToTarget.transform.position);
            //There needs to be a check for when the navmesh has finished before calling the desired action script
            
            
            //otherGameObject.GetComponent("OtherScript").DoSomething();
            //Conditional arguements for different actions, must fit the different call limitations of the action scripts
            if(DesiredAction == Pickupper){
            //issue: calling pickup requires a button to be pressed, and does not specify what to pick up in the function
            pickupper.ButtonCheck();
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
        }
 }
 
 void HasArrivedAtTarget(){
 hasArrived= true;
 //this is where the desired action gets called once navmesh has brought it to its target
 
 
 
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
