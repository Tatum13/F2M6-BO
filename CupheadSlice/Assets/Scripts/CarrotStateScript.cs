using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotStateScript : MonoBehaviour
{
    public float delay = 1.5f;
    private float timer;
    public int amountOfCarrots;
    private bool spawnCarrotLeft = true;
    public GameObject carrot;
    private AttackStates currentState = AttackStates.CARROTS;

    private enum AttackStates
    {
        CARROTS,
        EYEBEAMLAZER
    }

    void Start()
    {
        timer = delay;

        System.Random random = new System.Random();
        amountOfCarrots = random.Next(4, 7);
    }

    void Update()
    {
        switch (currentState)
        {
            case AttackStates.CARROTS:
                timer += Time.deltaTime;
                if (timer > delay)
                {
                    Instantiate(carrot, CalculateCarrotPosition(), Quaternion.identity);
                    timer = 0;
                    amountOfCarrots -= 1;
                    if (amountOfCarrots == 0)
                    {
                        currentState = AttackStates.EYEBEAMLAZER;
                    }
                }
                break;

            case AttackStates.EYEBEAMLAZER:
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
