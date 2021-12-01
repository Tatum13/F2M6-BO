using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotAttackScript : MonoBehaviour
{
    public float carrorHealth;

    public float attackingTimer;
    private float isAttacking;

    public Transform laserPoint;

    public GameObject laserPrefab;
    public GameObject target;

    private void Update()
    {
        //Animatie op hoofd wrijven en er komen carrots.

        //Animatie lazer.

        if (target)
        {
            GameObject laser = Instantiate(laserPrefab, laserPoint.position, laserPoint.rotation);
            Rigidbody2D rbLaser = laser.GetComponent<Rigidbody2D>();
        }
    }


}
