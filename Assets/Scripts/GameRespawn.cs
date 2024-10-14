using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;  // player respawn point
    public float threshold;  // death boundary

    private void Start()
    {
        // set respawn point
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            Debug.Log("Player fell below threshold! Respawning at: " + respawnPoint);
            transform.position = respawnPoint;
        }
    }

    public void UpdateRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
        Debug.Log("Respawn point updated to: " + respawnPoint);
    }
}
