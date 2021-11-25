using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedScript : MonoBehaviour
{
    private PlayerMovement pm;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)//als je op de ground bent dan mag je springen
    {

        if (collision.collider.tag == "Ground")
        {
            pm.isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)//als je niet op de ground ben dan mag je niet springen
    {
        if (collision.collider.tag == "Ground")
        {
            pm.isGrounded = false;
        }
    }
}
