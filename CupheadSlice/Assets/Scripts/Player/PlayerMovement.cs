using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField]
    private float walkSpeed = 1;

    public const string RIGHT = "right";
    public const string LEFT = "left";

    string buttonPressed;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            buttonPressed = RIGHT;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            buttonPressed = LEFT;
        }
        else
        {
            buttonPressed = null;
        }
    }

    private void FixedUpdate()
    {
        if (buttonPressed == RIGHT)
        {
            Debug.Log("Naar rechts");
            rb2d.velocity = new Vector2(walkSpeed, 0);
        }
        else if (buttonPressed == LEFT)
        {
            Debug.Log("Naar links");
            rb2d.velocity = new Vector2(-walkSpeed, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}
