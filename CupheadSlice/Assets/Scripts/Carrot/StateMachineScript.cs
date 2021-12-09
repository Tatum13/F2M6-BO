using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineScript : MonoBehaviour
{
    private float health;

    void Start()
    {
        Spawning();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    void Spawning()
    {
        // Roep de animatie aan

        // Wachten tot de animatie af is

        // If Animation Done:
        ShootingProjectiles();
    }

    void ShootingProjectiles()
    {
        // Roep de animatie aan

        // Choose random between 4 and 6

        // For random > 0, spawn projectile in the spawnareas, random -1

        // If random = 0 && health >= 0:
        ShootingLasers();
        // Else if health <= 0: 
        Die();
    }

    void ShootingLasers()
    {
        // Roep de animatie aan

        // Choose random between 2 and 3

        // For random > 0, find player pos., fire laser. Random -1.

        // if random = 0 && health >= 0:
        ShootingProjectiles();
        // Else if health <= 0:
        Die();
    }

    void Die()
    {
        // Roep de animatie aan

        // Speel geluid af

        // Ga naar het deathscreen
    }
}
