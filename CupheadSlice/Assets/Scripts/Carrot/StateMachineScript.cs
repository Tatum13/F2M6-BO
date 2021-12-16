using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineScript : MonoBehaviour
{
    private float health;

    private float screenWidth;
    private float spawnAreaL;
    private float spawnAreaR;

    public float timer;

    private bool rightSpawn;

    public GameObject projectile;

    void Start()
    {
        Spawning();

        screenWidth = Screen.width; // Schermbreedte wordt gecontroleerd
        spawnAreaL = screenWidth / 5 * 2; // Linker spawn area (0 tot spawnAreaL)
        spawnAreaR = screenWidth - screenWidth / 5 * 2; // Rechter spawn area (spawnAreaR tot screenWidth)
    }

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }

        timer -= Time.deltaTime;
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
        // Choose random between 4 and 6 for the amount of carrots
        int carrotAmount = createRandomBetween(4, 6);

        // Timer houdt bij of er weer een wortel gespawned kan worden
        // Spawnlocatie: helft van het scherm - bepaalde offset



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

    int createRandomBetween(int a, int b)
    {
        int randomNum;

        System.Random random = new System.Random();

        randomNum = random.Next(a, b);

        return randomNum;
    }
}
