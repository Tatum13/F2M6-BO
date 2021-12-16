using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCarrotScript2 : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float rotationSpeed;
    public int health = 1;
    public PlayerHealthScript playerHealthScript;

    private void Start()
    {
        target = GameObject.Find("Cuphead").transform;
        playerHealthScript = GameObject.Find("Cuphead").GetComponent<PlayerHealthScript>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        transform.up = transform.position - target.position;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealthScript.playerHealth -= 1;
            //Moet de animatie van carrot kapot gaan afspelen.
            Destroy(gameObject);
        }
    }
}
