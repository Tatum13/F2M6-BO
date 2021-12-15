using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int playerHealth = 3;

    void Update()
    {
        if(playerHealth <= 0)
        {
            //Animatie/deathscreen.
        }
    }
}
