using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;  // The position where the player will respawn
    public float threshold;  // The Y-coordinate below which the player "dies" and respawns

    private void Start()
    {
        // Set the initial respawn point (optional: this can be set at the player's starting position)
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if player falls below the threshold (indicating death)
        if (transform.position.y < threshold)
        {
            Debug.Log("Player fell below threshold! Respawning at: " + respawnPoint);
            // Respawn player at the last checkpoint
            transform.position = respawnPoint;
        }
    }

    // This method can be called by the CheckPoint script to update the respawn point
    public void UpdateRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
        Debug.Log("Respawn point updated to: " + respawnPoint);
    }
}
