using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBulletsScript : MonoBehaviour
{
    public float bulletBlueSpeed = 10f;
    public float bulletBlueDamage = 10f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector2(40, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BossCarrot")//Doet damage aan enemy met tag BossCarrot.
        {
            collision.gameObject.GetComponent<CarrotHealthScript>().carrotHealth -= bulletBlueDamage;
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()// Zodra de bullet uit het scherm is dan word die vernietigd.
    {
        Destroy(gameObject);
    }



}
