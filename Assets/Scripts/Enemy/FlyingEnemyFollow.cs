using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingEnemyFollow : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent flyingEnemy;
    public float hoverHeight = 2.1f;  // Height above the ground to simulate flying
    
    // Start is called before the first frame update
    void Start()
    {
        // Ensure the agent doesn't automatically adjust its Y position
        flyingEnemy.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the player using NavMesh (X and Z axis only)
        flyingEnemy.SetDestination(player.position);

        // Use a Raycast to determine the current ground height below the enemy
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // Set the Y position to hoverHeight above the ground
            Vector3 pos = transform.position;
            pos.y = hit.point.y + hoverHeight;
            transform.position = pos;
        }
    }
}
