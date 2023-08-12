using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerEnemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb;

    private bool isMoving;
    private bool isGrounded;

    private void Update()
    {

        if (rb.velocity.x >= 0.1f)
        {
            isMoving = true;
        }
        else if (rb.velocity.x == 0f) { isMoving = false; }


        if (rb.velocity.y == 0)
        {
            isGrounded = true;
        }
        else isGrounded = false;


        if (isGrounded == true && isMoving == true)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }

}