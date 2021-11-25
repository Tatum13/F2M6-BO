using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 1f;
    [SerializeField]
    private float jumpForce = 10f;

    private float jumpTimeCounter;
    [SerializeField]
    private float jumpTime;

    public bool isGrounded = false;
    private bool isJumping = false;

    private void Update()
    {
        Jump();

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * walkSpeed;//< ^ Lopen
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
