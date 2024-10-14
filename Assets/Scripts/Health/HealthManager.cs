using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public HealthBar healthBar;

    public int maxHealth = 5;
    public int currentHealth;

    // Setting up health and linking it to the healthbar
    void Start() {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Damages the player reflects on the healthbar
    public void damagePlayer(int damage) {
        currentHealth -= damage;
        
        if(currentHealth <= 0) {
            currentHealth = 0;
        }
        healthBar.setHealth(currentHealth);
    }

    void Update() {
        // Testing
        // if(Input.GetKeyDown(KeyCode.L)) {
        //     damagePlayer(1);
        // }
    }

}
