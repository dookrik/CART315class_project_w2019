using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    /* BEHAVIOUR TREE BY MARIE-ÈVE.
    This is one example of a behaviour tree.
    This script determines enemies behaviour.
     The following functions are implemented in this script:
     - If player has picked up object, enemy will run away from player.
     - If player hasn't picked up object, enemy will chase him.
     - When player is too far from enemy, enemy patrols a certain area infinitely.
     
     Please refer to the scene "BehaviourTreeTest" in order to see this script in live action.
     
     HOW TO USE THIS SCRIPT :
      -- THIS SCRIPT HAS TO BE PUT ON AN ENEMY.
      -- YOU NEED AN OBJECT THAT CAN BE PICKED UP WITH THE PICKUP SCRIPT
      -- YOU NEED A PLAYER THAT CAN MOVE
     
     THE NAV MESH AGENT COMPONENT OF THE GAME OBJECT HAS TO BE LINKED TO THE enemyAgent VARIABLE IN UNITY.
     THE ACTUAL PLAYER OBJECT (NOT THE ENEMY, BUT THE PLAYER) HAS TO BE LINKED TO player VARIABLE.
     THE ARRAY FOR PatrolPoints VARIABLE HAS TO BE SET UP TO THE DESIRED NUMBER IN UNITY, AND THEN, THE PATROL POINT OBJECTS (WHICH ARE EMPTY OBJECTS) EACH NEED TO BE LINKED TO PatrolPoints WITHIN THIS ARRAY.
     
     
  IT IS RECOMMENDED THAT THE LEVEL HAS A NAVMESH FOR THIS SCRIPT TO WORK AS IT USES A NAVMESH AGENT.
  
  IF YOU HAVE ANY QUESTIONS OR SEE ANY BUG PLEASE POST AN ISSUE IN THE GITHUB OR SEND ME A SLACK @Marie-Ève
  
  
  ***PLEASE NOTE, for now I am not sure how the pickup script works, therefore it hasn't been implemented into the test scene. If you wish to see what happens when player has object, run the game, then click on the enemy and simply check the bool 'Player Has Obj'****
    */
    

    private NavMeshAgent agent;
    public GameObject player;
    NavMeshController controller;
    
    public Transform[] PatrolPoints;
    private int currentPatrolPoint = 0;
    
    // Distance which player is detected
    private float enemyDistanceDetect = 3.0f;

    // If player does not have object, enemy chases him
    public bool playerHasObj = false;
    
    void Start() {
        agent = this.GetComponent<NavMeshAgent>(); 
        controller = GetComponentInParent<NavMeshController>();
        
        //Debug.Log(agent);
        //Debug.Break();
        
        // Enemy starts his round
        GoToNextPoint();
    }
    
    void GoToNextPoint() {
                    // Returns if no points have been set up
            if (PatrolPoints.Length == 0)
                return;
   
        controller.NavMeshProvider(PatrolPoints[currentPatrolPoint].position);
        
            // Set the agent to go to the currently selected destination.   
//agent.SetDestination(PatrolPoints[currentPatrolPoint].position);

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            currentPatrolPoint = (currentPatrolPoint + 1) % PatrolPoints.Length;
    }
    
    // Checks collision with ball to see if player has object
    //(*currently not fully implemented and functional*)
    private void OnTriggerEnter (Collider collider) {
        if(collider.gameObject.tag == "pickupable") {
            playerHasObj = true;
            Debug.Log("player has obj");
        }
    }
    
    
    void Update() {
        
        //Actual distance between player and enemy.
        float distance = Vector3.Distance(transform.position, player.transform.position);
    
        
        // If the player is too close to the enemy
        if (distance < enemyDistanceDetect) {
            
            
            // If player has picked up object, enemy will run away from player
            if (playerHasObj) {   
                Vector3 dirToPlayer = transform.position - player.transform.position;
                Vector3 newPos = transform.position + dirToPlayer;
                 controller.NavMeshProvider(newPos);
            // If player hasn't picked up object, enemy will run towards player and chase him
            } else {                     
                controller.NavMeshProvider(player.transform.position);
            }
        
        // If the player is too far from enemy  
        } else {
            // When enemy has reached one patrol point, go to the next one                          
                if (!agent.pathPending && agent.remainingDistance < 0.5f) GoToNextPoint();                           
    }
}
    
}
