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

    public float normalSpeed = 5f;            // The player's normal speed
    public float slowedSpeed = 2f;            // The slowed down speed
    public float slowdownDuration = 5f;       // Duration of slowdown effect in seconds
    private bool isSlowed = false;            // Whether the player is currently slowed
    private float slowdownTimer = 0f;         // Timer for slowdown effect

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] public bool isSlim;
    [SerializeField] public bool isMoving;
    [SerializeField] Animator animator;

    private void Start()
    {
        currentSpeed = runSpeed;
    }

     void Update()
    {
        if (isSlowed)
        {
            slowdownTimer -= Time.deltaTime;
            if (slowdownTimer <= 0f)
            {
                isSlowed = false;
                currentSpeed = runSpeed;
            }
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetTrigger("isJumping");
        }

        if(rb.velocity.x <= 0.1f)
        {
            isMoving = true;
        } else if(rb.velocity.x == 0f) { isMoving = false; }

    }

    public void ApplySlowdown()
    {
        isSlowed = true;
        slowdownTimer = slowdownDuration;
        currentSpeed = slowedSpeed;
    }
    public bool  isGrounded()
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
