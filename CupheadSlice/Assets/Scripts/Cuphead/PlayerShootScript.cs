using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject blueBulletPrefab;

    public float blueBulletForce = 50f;

    private float shootTimer;
    public float reloadTimer;


    private void Start()
    {
        shootTimer = reloadTimer;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            shootTimer += Time.deltaTime; // Start de timer.
            if (shootTimer > reloadTimer)
            {
                Shoot();
                shootTimer = 0.0f;
            }
        }

    }

    void Shoot()//Maakt de bullet aan en schiet.
    {
        GameObject blueBullet = Instantiate(blueBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = blueBullet.GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(firePoint.up * blueBulletForce, ForceMode2D.Impulse);
        }
    }





}
