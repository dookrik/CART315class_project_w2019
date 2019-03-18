
using UnityEngine;
using UnityEngine.AI;
public class NavMeshController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    // public LocomotionController locomotionCtl;
    private RigidBodyController locomotionCtl;
    private Rigidbody rigidb;
    Vector3 direction;

    private Vector3 destination;

    /* NavMeshProvider() function is for leading player to an assigned destination. this destination
     parameter is passed by the one who call this function. a position(not direction) is requaired in this function.  
     by now, it is not calling locomote function in order to make movement going the right way. 
   */

    //void NavMeshProvider(Vector3 destination)
    //{
    //   // agent.velocity = locomotionCtl.controller.velocity;

    //    agent.SetDestination(destination);

    //    this.transform.position += Vector3.Normalize(agent.steeringTarget - this.transform.position) * 0.1f;

    //   // locomotionCtl.Locomote(Vector3.Normalize(agent.steeringTarget - this.transform.position), false);
    //}


    /* FixedUpdate() function is for standalone testing navmesh function. Push down mouse left button to set
       up a destination for navmesh agent. if you want to test, uncomment
       "locomotionCtl.Locomote(Vector3.Normalize(agent.steeringTarget - this.transform.position), false)"
        and comment the line blew. by now, it is not calling locomote function in order to make movement
        going the right way. 
    */
    private void Start()
    {
        locomotionCtl = GetComponent<RigidBodyController>();
        rigidb = GetComponent<Rigidbody>();
        agent.SetDestination(agent.transform.position);
        destination = agent.transform.position;
    }
    void FixedUpdate()
    {
        agent.velocity = rigidb.velocity;

        if (Input.GetMouseButtonDown(0)) {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                destination = hit.point;


            }
        }
        if (Vector3.Distance(this.transform.position, destination) > 0.1f)
       locomotionCtl.Locomote(Vector3.Normalize(agent.steeringTarget - this.transform.position));

     //  this.transform.position += Vector3.Normalize(agent.steeringTarget - this.transform.position) * 0.1f;
       
    }

}

