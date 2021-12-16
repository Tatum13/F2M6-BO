using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotStateScript : MonoBehaviour
{
    public float spawnDelay = 3f;
    public float laserDelay = 2.5f;
    public float carrotDelay = 1.5f;
    private float timer;
    public int amountOfCarrots;
    public int amountOfLasers;
    public GameObject player;
    private bool spawnCarrotLeft = true;
    public GameObject carrot;
    private states currentState = states.SPAWNING;
    public SoundFXScript soundFXScript;
    Animator animator;

    private enum states
    {
        SPAWNING,
        CARROTS,
        EYEBEAMLAZER,
        DYING
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        timer = spawnDelay;
    }

    void Update()
    {
        switch (currentState)
        {
            case states.SPAWNING:
                soundFXScript.carrotRise.Play();
                timer -= Time.deltaTime;
                System.Random random = new System.Random();
                if (timer < 0)
                {
                    amountOfCarrots = random.Next(4, 7);
                    currentState = states.CARROTS;
                    soundFXScript.carrotMindmeltStart.Play();
                    soundFXScript.carrotMindmeltLoop.Play();
                    timer = carrotDelay;
                }
                break;

            case states.CARROTS:
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    Instantiate(carrot, CalculateCarrotPosition(), Quaternion.identity);
                    timer = carrotDelay;
                    amountOfCarrots -= 1;
                    if (amountOfCarrots == 0)
                    {
                        System.Random random2 = new System.Random();
                        amountOfLasers = random2.Next(3, 5);
                        animator.SetBool("isAttackingCarrots", false);
                        animator.SetBool("isAttackingPsybeam", true);
                        soundFXScript.carrotMindmeltLoop.Stop();

                        currentState = states.EYEBEAMLAZER;
                    }
                }
                break;

            case states.EYEBEAMLAZER:
                timer -= Time.deltaTime;
                Vector3 target = CalculateLaserTarget();
                if (timer < 0)
                {
                    timer = laserDelay;
                    amountOfLasers -= 1;
                    Debug.Log("Laser spawned to: " + target);

                    if (amountOfLasers == 0)
                    {
                        System.Random random3 = new System.Random();
                        amountOfCarrots = random3.Next(4, 7);
                        animator.SetBool("isAttackingPsybeam", false);
                        animator.SetBool("isAttackingCarrots", true);
                        soundFXScript.carrotMindmeltStart.Play();
                        soundFXScript.carrotMindmeltLoop.Play();
                        currentState = states.CARROTS;
                    }
                }
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

    private Vector3 CalculateLaserTarget()
    {
        Vector3 laserTarget = player.transform.position;

        return laserTarget;
    }
}
