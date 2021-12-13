using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCarrotAttack : MonoBehaviour
{
    private float screenWidth;

    private float spawnAreaL;
    private float spawnAreaR;

    void Start()
    {
        screenWidth = Screen.width; // Schermbreedte wordt gecontroleerd
        spawnAreaL = screenWidth / 5 * 2; // Linker spawn area 
        spawnAreaR = screenWidth - screenWidth / 5 * 2; // Rechter spawn area
    }

    
}
