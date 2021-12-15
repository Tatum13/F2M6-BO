using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXScript : MonoBehaviour
{
    public AudioSource[] startFX = new AudioSource[4];

    private int randomInt;

    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        randomInt = random.Next(0, 4);

        startFX[randomInt].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
