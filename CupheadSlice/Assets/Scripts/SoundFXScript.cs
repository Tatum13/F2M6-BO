using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXScript : MonoBehaviour
{
    public AudioSource[] startFX = new AudioSource[4];

    public AudioSource carrotRise;
    public AudioSource carrotPsychicStart;
    public AudioSource carrotMindmeltStart;
    public AudioSource carrotMindmeltLoop;

    private int randomInt;

    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        randomInt = random.Next(0, 4);

        startFX[randomInt].Play();
    }
}
