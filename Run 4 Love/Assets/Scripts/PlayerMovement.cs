using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private bool isFacingRight;
    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        currentSpeed = runSpeed;
    }

    void Update()
    {
        currentSpeed = runSpeed;

        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

    }

    private bool  isGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);

    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal >  0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
