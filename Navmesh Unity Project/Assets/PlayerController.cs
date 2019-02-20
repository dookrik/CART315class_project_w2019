
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public LocomotionController locomotionCtl;
    Vector3 direction;

    //private void Start()
    //{
    //    direction = new Vector3();
    //    // Don’t update position automatically
    //    //agent.updatePosition = false;
    //}
    // Update is called once per frame
    void Update()
    {

        //direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //locomotionCtl.Locomote(direction, false);
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
               //direction = hit.point;
            }
        }

        // Vector3 worldDeltaPosition = agent.steeringTarget - transform.position;
        // Debug.Log("distance:: " + worldDeltaPosition);
        // if (worldDeltaPosition.magnitude >Mathf.Abs(0.7f))
        //  {
        // Debug.Log(agent.steeringTarget);
        //locomotionCtl.Locomote(agent.steeringTarget, false);
        //}
        //  agent.Move(agent.nextPosition);
        //transform.position = agent.nextPosition;

    }

    /*  void OnAnimatorMove()
      {
          // Update position to agent position
         // Debug.Log("here");
          transform.position = agent.nextPosition;
      }*/
}


//
//public class PlayerController : MonoBehaviour
//{

//    public Transform playerTrans;
//    public float speed = 2;
//    public float turnSpeed = 3;

//    private NavMeshAgent agent;
//    private Vector3 desVelocity;
//    private CharacterController charControl;

//    void Start()
//    {

//        this.agent = this.gameObject.GetComponent<NavMeshAgent>();
//        this.charControl = this.gameObject.GetComponent<CharacterController>();

//        this.agent.destination = this.playerTrans.position;

//        return;
//    }

//    void Update()
//    {

//        Vector3 lookPos;
//        Quaternion targetRot;

//        this.agent.destination = this.playerTrans.position;
//        this.desVelocity = this.agent.desiredVelocity;

//        agent.updatePosition = false;
//        agent.updateRotation = false;

//        lookPos = this.playerTrans.position - this.transform.position;
//        lookPos.y = 0;
//        targetRot = Quaternion.LookRotation(lookPos);
//        this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * this.turnSpeed);

//        this.charControl.Move(this.desVelocity.normalized * this.speed * Time.deltaTime);

//        this.agent.velocity = this.charControl.velocity;

//        return;
//    }
//}
////