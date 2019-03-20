using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public NavMeshAgent enemyAgent;
    public GameObject player;
    
    public Transform[] PatrolPoints;
    private int currentPatrolPoint = 0;
    
    private float enemyDistanceDetect = 3.0f;

    public bool playerHasObj = false;
    
    private int index;
    
    void start() {
         //enemyAgent.autoBraking = false;
        
        GoToNextPoint();

        //        PatrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoints");
        //Debug.Log(PatrolPoints.Length);
    }
    
    void GoToNextPoint() {
                    // Returns if no points have been set up
            if (PatrolPoints.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            enemyAgent.SetDestination(PatrolPoints[currentPatrolPoint].position);

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            currentPatrolPoint = (currentPatrolPoint + 1) % PatrolPoints.Length;
    }
    
    void Update() {
        
        //Actual distance between player and enemy.
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 dirToPlayer = transform.position - player.transform.position;
        
        if (distance < enemyDistanceDetect) {
            
            
            // If player has picked up object, enemy will run away from player
            if (playerHasObj) {               
                Vector3 newPos = transform.position + dirToPlayer;
                     enemyAgent.SetDestination(newPos);
            // If player hasn't picked up object, enemy will run towards player
            } else {
                //Vector3 newPos = transform.position - dirToPlayer;
                     enemyAgent.SetDestination(player.transform.position);
            }
        
            
        } else {
            Debug.Log("outside of distance");
            
                             if (!enemyAgent.pathPending && enemyAgent.remainingDistance < 0.5f)
                GoToNextPoint();
            
            
            
        }
        
    }

}
