using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    [Header ("ATTRIBUTES")]
    [SerializeField]
    private float walkSpeed = 1f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float dashDistance = 15f;
    [SerializeField]
    private float jumpTime;
    private float jumpTimeCounter;
    private float doubbleTapTime;

    [Header("BOOLS")]
    public bool isGrounded = false;
    [SerializeField]
    private bool isJumping = false;
    [SerializeField]
    private bool isDashing = false;

    [Header("Unity stuff")]
    KeyCode lastKeyCode;


    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Walk();
        Dash1();
        Jump();
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
    private void Dash1()
    {
        if (Input.GetKeyDown(KeyCode.A))//naar links dashen
        {
            if (doubbleTapTime > Time.time && lastKeyCode == KeyCode.A)
            {
                StartCoroutine(Dash2(-1f));
            }
            else
            {
                doubbleTapTime = Time.time + 0.5f;
            }
            lastKeyCode = KeyCode.A;
        }
        if (Input.GetKeyDown(KeyCode.D))//naar rechts dashen
        {
            if (doubbleTapTime > Time.time && lastKeyCode == KeyCode.D)
            {
                StartCoroutine(Dash2(1f));
            }
            else
            {
                doubbleTapTime = Time.time + 0.4f;
            }
            lastKeyCode = KeyCode.D;
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
    IEnumerator Dash2(float diraction)
    {
        isDashing = true;
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
        rb2d.AddForce(new Vector2(dashDistance * diraction, 0f), ForceMode2D.Impulse);
        float gravity = rb2d.gravityScale;
        rb2d.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        rb2d.gravityScale = gravity;
    }
}
