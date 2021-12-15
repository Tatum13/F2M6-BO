using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotHealthScript : MonoBehaviour
{
    public float carrotHealth = 100;

    public AudioClip knockOutSound;

    private void Update()
    {
        if(carrotHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(knockOutSound, transform.position);
            Destroy(gameObject); // Hier komt de animatie.
        }
    }
}
