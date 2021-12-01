using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    private float walkSpeed = 1f;
    [SerializeField]
    private float jumpForce = 10f;

    private float jumpTimeCounter;
    [SerializeField]
    private float jumpTime;

    public bool isGrounded = false;
    private bool isJumping = false;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        Walk();
    }
    private void Walk()
    {
        if (Input.GetKey(KeyCode.D) && isGrounded == true)
        {
            rb2d.AddForce(Vector2.right * walkSpeed);
            Debug.Log("rechts");
        }
        if (Input.GetKey(KeyCode.A) && isGrounded == true)
        {
            rb2d.AddForce(-Vector2.right * walkSpeed);
            Debug.Log("links");
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector2.right * walkSpeed);
            Debug.Log("rechts");
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(-Vector2.right * walkSpeed);
            Debug.Log("links");
        }
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            StartCoroutine(JumpCoroutine());
        }
    }
    IEnumerator JumpCoroutine()
    {
        isJumping = true;
        jumpTimeCounter = jumpTime;

        Rigidbody2D _rb = gameObject.GetComponent<Rigidbody2D>();
        while (Input.GetButton("Jump"))
        {
            if(jumpTimeCounter > 0)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            yield return null;
        }
        isJumping = false;
    }
}
