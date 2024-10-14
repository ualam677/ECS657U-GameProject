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

        // Manually control the Y position to simulate hovering
        Vector3 pos = transform.position;
        pos.y = pos.y + hoverHeight;
        transform.position = pos;
    }
}
