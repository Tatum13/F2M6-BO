using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public Transform firePoint;//Naar rechts.
    public Transform firePoint2;//Naar boven.
    public Transform firePoint3;//Naar links.
    public Transform firePoint4;//Naar links schuin naar boven.
    public Transform firePoint5;//Naar rechts schuin naar boven.

    public GameObject blueBulletPrefab;

    private Transform activeFirePoint;

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
                //Shoot(new Vector2 (1000, 0));
                //shootTimer = 0.0f;

                if (Input.GetKey(KeyCode.LeftArrow))//Schiet naar links.
                {
                    activeFirePoint = firePoint3;
                    Shoot3(new Vector2(-1000, 0));
                    shootTimer = 0.0f;
                }
                if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))//Schiet links schuin naar boven.
                {
                    activeFirePoint = firePoint4;
                    Shoot4(new Vector2(-1000, 1000));
                    shootTimer = 0.0f;
                }
                if (Input.GetKey(KeyCode.RightArrow))//Schiet naar rechts.
                {
                    activeFirePoint = firePoint;//Naar rechts
                    Shoot(new Vector2 (1000, 0));
                    shootTimer = 0.0f;
                }
                if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))//Schiet rechts schuin naar boven.
                { 
                    Shoot5(new Vector2(1000, 1000));
                    shootTimer = 0.0f;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    activeFirePoint = firePoint2; //Naar boven.
                    Shoot2(new Vector2(0, 1000));
                    shootTimer = 0.0f;
                }
            }
        }


    }

    void Shoot(Vector2 direction)//Maakt de bullet aan en schiet maar rechts.
    {
        GameObject blueBullet = Instantiate(blueBulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = blueBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction);
    }

    void Shoot2(Vector2 direction)//Naar boven.
    {
        GameObject blueBullet = Instantiate(blueBulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D rb = blueBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction);
    }

    void Shoot3(Vector2 direction)//Naar Links.
    {
        GameObject blueBullet = Instantiate(blueBulletPrefab, firePoint3.position, firePoint3.rotation);
        Rigidbody2D rb = blueBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction);
    }

    void Shoot4(Vector2 direction)//Naar Links schuin naar boven.
    {
        GameObject blueBullet = Instantiate(blueBulletPrefab, firePoint4.position, firePoint4.rotation);
        Rigidbody2D rb = blueBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction);
    }

    void Shoot5(Vector2 direction)//Naar rechts schuin naar boven.
    {
        GameObject blueBullet = Instantiate(blueBulletPrefab, firePoint5.position, firePoint5.rotation);
        Rigidbody2D rb = blueBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction);
    }





}
