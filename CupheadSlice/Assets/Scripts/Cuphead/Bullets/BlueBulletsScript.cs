using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBulletsScript : MonoBehaviour
{
    public float bulletBlueSpeed = 10f;
    public float bulletBlueDamage = 10f;

    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BossCarrot")//Doet damage aan enemy met tag BossCarrot.
        {
            collision.gameObject.GetComponent<CarrotHealthScript>().carrotHealth -= bulletBlueDamage;
            Destroy(gameObject);
        }


        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Wall")
            {
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "Player" && collision.gameObject.tag == "Sky")
            {

            }
        }
        void OnBecameInvisible()// Zodra de bullet uit het scherm is dan word die vernietigd.
        {
            Destroy(gameObject);
        }
    } 
}