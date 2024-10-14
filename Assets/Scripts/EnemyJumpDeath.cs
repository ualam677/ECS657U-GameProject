using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpDeath : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Npte: Used raycasting because player is kinematic. Dosen't rely on physics like velocity to determine if the player is directly above the enemy

            // Cast a ray from the player's position downwards
            RaycastHit hit;
            Vector3 rayOrigin = other.transform.position;
            Vector3 rayDirection = Vector3.down;

            if (Physics.Raycast(rayOrigin, rayDirection, out hit, Mathf.Infinity))
            {
                // Check if the ray hit this enemy object
                if (hit.collider.gameObject == gameObject)
                {
                    // Destroy the enemy if the ray hits it from above
                    Destroy(gameObject);
                }
            }
        }
    }
}
