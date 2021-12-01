using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 1f;
    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private float dashSpeed = 3f;
    private float dashTime;
    private float startDashTime;

    private float jumpTimeCounter;
    [SerializeField]
    private float jumpTime;

    public bool isGrounded = false;
    private bool isJumping = false;

    private void Start()
    {
        dashTime = startDashTime;
    }

    private void Update()
    {
        Jump();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * walkSpeed;//< ^ Lopen
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isGrounded == true)
        {
            StartCoroutine(JumpCoroutine());
            Debug.Log("Jump");
        }
    }
    IEnumerator JumpCoroutine()
    {
        isJumping = true;
        jumpTimeCounter = jumpTime;

        Rigidbody2D _rb = gameObject.GetComponent<Rigidbody2D>();
        while (Input.GetKey(KeyCode.Z))
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

    private void Dash()
    {
        Debug.Log("Dash");
    }
}
