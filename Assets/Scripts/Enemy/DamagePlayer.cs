using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageAmount = 1;
    public float damageCooldown = 1.5f; // Cooldown in seconds
    private float nextDamageTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player") && Time.time >= nextDamageTime)
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;

            HealthManager playerHealth = FindAnyObjectByType<HealthManager>();
            if (playerHealth != null)
            {
                playerHealth.damagePlayer(damageAmount, hitDirection);
                nextDamageTime = Time.time + damageCooldown; // Set the next time the enemy can deal damage
            }
        }
    }
}
