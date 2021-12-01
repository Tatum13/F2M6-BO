using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedScript : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement pm;

    private void OnCollisionEnter2D(Collision2D collision)//als je op de ground bent dan mag je springen
    {

        if (collision.collider.tag == "Ground")
        {
            //Debug.Log("Fix de jumpen reeeee");
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
