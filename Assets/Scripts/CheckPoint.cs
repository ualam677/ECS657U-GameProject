using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameRespawn gameRespawn;
    [SerializeField] List<GameObject> checkPoints; // Changed to a List<GameObject> to allow multiple checkpoints

    private void OnTriggerEnter(Collider other)
    {
        if (checkPoints.Contains(other.gameObject)) // Check if the collided object is in the list of assigned checkpoints
        {
            gameRespawn.UpdateRespawnPoint(player.transform.position);
            Debug.Log("Checkpoint triggered! New checkpoint set at: " + player.transform.position);
            Destroy(other.gameObject);
        }
    }
}