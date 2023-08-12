using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private bool isFacingRight;

    [SerializeField] private float fatSpeed = 8f;   // The player's speed when fat
    public float slowedSpeed = 2f;                  // The slowed down speed
    public float slowdownDuration = 5f;             // Duration of slowdown effect in seconds
    private bool isSlowed = false;                  // Whether the player is currently slowed
    private float slowdownTimer = 0f;               // Timer for slowdown effect

    public float slimSpeed = 10f;                   // The player's speed in Slim form
    public float fatDuration = 15f;                 // The duration the player is Fat
    public float extraFatDuration = 5f;

    private float fatTimer;                       // Der Timer wie lange man fett ist

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] public bool isSlim;
    [SerializeField] public bool isMoving;
    [SerializeField] Animator animator;

    private void Start()
    {
        currentSpeed = fatSpeed;
        fatTimer = fatDuration;
    }

     void Update()
     {
        // Der Timer für den Slow
        if (fatTimer > 0)
        {
            fatTimer -= Time.deltaTime;
            isSlim = false;

            if(!isSlowed)
            { currentSpeed = fatSpeed; }
            
            if (fatTimer <= 0 && !isSlowed)
            {
                fatTimer = 0;
                currentSpeed = slimSpeed;
                isSlim = true;
            }
        }
        else
        {
            currentSpeed = slimSpeed;
            isSlim = true;
        }



        if (isSlowed)
        {
            slowdownTimer -= Time.deltaTime;
            if (slowdownTimer <= 0f)
            {
                isSlowed = false;
                currentSpeed = fatSpeed;
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
        } else if (Mathf.Approximately(rb.velocity.x, 0f)) { isMoving = false; }

    }

    public void ApplySlowdown()
    {
        isSlowed = true;
        slowdownTimer = slowdownDuration;
        currentSpeed = slowedSpeed;
    }

    // Funktion, um den Fattimer zu verlängern
    public void ExtendFatTimer()
    {
        fatTimer += extraFatDuration;
    }

    public bool  isGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);

        // Faster descent when pressing Down key in mid-air
        if (!isGrounded() && Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 1.5f);
        }
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
