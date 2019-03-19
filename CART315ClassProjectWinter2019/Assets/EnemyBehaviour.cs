using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public NavMeshAgent enemyAgent;
    public GameObject player;
    private float enemyDistanceDetect = 3.0f;
    
    //Wandering AI
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    
    public bool playerHasObj = false;
    
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
                // For this one we need an AI that will calculate the quickest path to the player.
            } else {
                //Vector3 newPos = transform.position - dirToPlayer;
                     enemyAgent.SetDestination(player.transform.position);
            }
        
            
        } else {
            
    //Else if enemy isn't within the range he walks around        
            
        }
        
    }

}
