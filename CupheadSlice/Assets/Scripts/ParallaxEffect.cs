using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 lastPlayerPosition;
    
    public float parallaxEffectMultiplier = 0.05f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.transform; // playerTransform is set to the current transform of the Player.
        lastPlayerPosition = playerTransform.position; // lastPlayerPosition takes just the Position of playerTransform.
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = new Vector3(playerTransform.position.x - lastPlayerPosition.x, 0f, 0f);
        transform.position -= deltaMovement * parallaxEffectMultiplier;
        lastPlayerPosition = playerTransform.position;
    }
}
