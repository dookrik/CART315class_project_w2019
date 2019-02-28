
using UnityEngine;
using UnityEngine.AI;
public class NavMeshController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public LocomotionController locomotionCtl;
    Vector3 direction;

    /* NavMeshProvider() function is for leading player to an assigned destination. this destination parameter is passed by the one who call this function.
     a position(not direction) is requaired in this function.   
   */

    void NavMeshProvider(Vector3 destination)
    {
        agent.velocity = locomotionCtl.controller.velocity;
        //direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //locomotionCtl.Locomote(direction, false);
        agent.SetDestination(destination);

        this.transform.position += Vector3.Normalize(agent.steeringTarget - this.transform.position) * 0.1f;


        //locomotionCtl.Locomote(Vector3.Normalize(agent.steeringTarget - this.transform.position), false);
    }

    /* FixedUpdate() function is for testing standalone by hiting mouse left button to set up a destination for navmesh agent.
        if you want to test, uncomment "locomotionCtl.Locomote(Vector3.Normalize(agent.steeringTarget - this.transform.position), false)"
        and comment the line blew. by now, it is not calling locomote function in order to make movement going the right way. 
    */

    void FixedUpdate()
    {
        agent.velocity = locomotionCtl.controller.velocity;
        //direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //locomotionCtl.Locomote(direction, false);
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                //direction = hit.point;
              //  Debug.Log("point===" + hit.point);
            }
        }
        //locomotionCtl.Locomote(Vector3.Normalize(agent.steeringTarget - this.transform.position), false);
        this.transform.position += Vector3.Normalize(agent.steeringTarget - this.transform.position) * 0.1f;
       
    }





    //this.transform.position += Vector3.Normalize(agent.steeringTarget - this.transform.position) * 0.1f;
    //Debug.Log(Vector3.Normalize(agent.steeringTarget - this.transform.position));



    // Vector3 worldDeltaPosition = agent.steeringTarget - transform.position;
    // Debug.Log("distance:: " + worldDeltaPosition);
    // if (worldDeltaPosition.magnitude >Mathf.Abs(0.7f))
    //  {
    // Debug.Log(agent.steeringTarget);
    //locomotionCtl.Locomote(agent.steeringTarget, false);
    //}
    //  agent.Move(agent.nextPosition);
    //transform.position = agent.nextPosition;



    /*  void OnAnimatorMove()
      {
          // Update position to agent position
         // Debug.Log("here");
          transform.position = agent.nextPosition;
      }*/



}

