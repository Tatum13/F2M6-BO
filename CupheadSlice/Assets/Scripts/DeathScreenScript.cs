using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenScript : MonoBehaviour
{
    public GameObject deathObjects;

    public void EnableDeathScreen()
    {
        deathObjects.SetActive(true);
        Time.timeScale = 0;
    }

}
