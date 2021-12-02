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
        Jump();
    }
    private void Walk()
    {
        if(!isDashing)
        {
            Vector2 movement = Vector2.zero;
            if (Input.GetKey(KeyCode.RightArrow) && isGrounded == true)
            {
                movement += Vector2.right * walkSpeed;
                Debug.Log("rechts");
            }
            if (Input.GetKey(KeyCode.LeftArrow) && isGrounded == true)
            {
                movement += Vector2.left * walkSpeed;
               Debug.Log("links");
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
               movement += Vector2.right * walkSpeed;
             Debug.Log("rechts");
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movement += Vector2.left * walkSpeed;
                Debug.Log("links");
            }
            rb2d.velocity = new Vector2(movement.x, rb2d.velocity.y);
        }
        else
        {
            isDashing = true;
        }
    }
    private void Dash1()
    {
        if (isDashing)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))//naar links dashen
            {
                if (doubbleTapTime > Time.time && lastKeyCode == KeyCode.LeftArrow)
                {
                    StartCoroutine(Dash2(-1f));
                }
                else
                {
                    doubbleTapTime = Time.time + 0.5f;
                }
                lastKeyCode = KeyCode.LeftArrow;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))//naar rechts dashen
            {
                if (doubbleTapTime > Time.time && lastKeyCode == KeyCode.RightArrow)
                {
                    StartCoroutine(Dash2(1f));
                }
                else
                {
                    doubbleTapTime = Time.time + 0.5f;
                }
                lastKeyCode = KeyCode.RightArrow;
            }
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
    IEnumerator Dash2(float direction)
    {
        
        if (!isDashing)
        {
            isDashing = true;
            Vector2 movement = Vector2.zero;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);

            /*rb2d.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);*/
            movement += new Vector2(dashDistance * direction, 0f);

            float gravity = rb2d.gravityScale;
            rb2d.gravityScale = 0;
            yield return new WaitForSeconds(0.3f);

            
            rb2d.gravityScale = gravity;
        }
        isDashing = false;

    }
}
