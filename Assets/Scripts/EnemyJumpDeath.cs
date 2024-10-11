using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpDeath : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the enemy's top is the player
        if (other.CompareTag("Player"))
        {
            Die();
        }
    }

    void Die()
    {
        // Perform any death animation, sound effects, etc. here
        Destroy(gameObject);  // Destroy the enemy object
    }
}
