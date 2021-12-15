using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotStateScript : MonoBehaviour
{

    public float spawnDelay = 3f;
    public float delay = 1.5f;
    private float timer;
    public int amountOfCarrots;
    private bool spawnCarrotLeft = true;
    public GameObject carrot;
    private states currentState = states.SPAWNING;

    private enum states
    {
        SPAWNING,
        CARROTS,
        EYEBEAMLAZER
    }

    void Start()
    {
        timer = spawnDelay;

        System.Random random = new System.Random();
        amountOfCarrots = random.Next(4, 7);
    }

    void Update()
    {
        switch (currentState)
        {
            case states.SPAWNING:
                // AFTER 1.18 SECONDS, THE SPAWNING ANIMATION IS OVER.
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    currentState = states.CARROTS;
                    timer = delay;
                }
                break;

            case states.CARROTS:
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    Instantiate(carrot, CalculateCarrotPosition(), Quaternion.identity);
                    timer = delay;
                    amountOfCarrots -= 1;
                    if (amountOfCarrots == 0)
                    {
                        currentState = states.EYEBEAMLAZER;
                    }
                }
                break;

            case states.EYEBEAMLAZER:
                Debug.Log("next case");
                break;
        }


    }
    private Vector3 CalculateCarrotPosition()
    {
        Vector3 spawnLocation = new Vector3();
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        spawnLocation.y = screenBounds.y;

        if (spawnCarrotLeft)
        {
            spawnLocation.x = Random.Range((-screenBounds.x * 0.9f), 0 - (screenBounds.x * 0.2f));
            spawnCarrotLeft = false;
        }
        else
        {
            spawnLocation.x = Random.Range(0 + (screenBounds.x * 0.2f), 0 + (screenBounds.x * 0.9f));
            spawnCarrotLeft = true;
        }
        return spawnLocation;
    }
}
