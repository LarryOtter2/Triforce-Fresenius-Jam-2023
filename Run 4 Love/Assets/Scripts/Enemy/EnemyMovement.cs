using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float dirX;

    [SerializeField]
    float moveSpeed = 3f;

    [SerializeField] Animator animator;

    Rigidbody2D rb;

    bool facingRight = false;

    Vector3 localScale;

    // Use this for initialization
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
           if (transform.position.x < 9f)
              dirX = -1f;
          else if (transform.position.x > -9f)
              dirX = 1f;
        */
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    void FixedUpdate()
    {
       
    }

    /*
    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= 1;

        transform.localScale = localScale;
    }
    */

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
            {
            case "CliffJump":
                rb.AddForce(Vector2.up * 800f);
                animator.SetTrigger("Jump");
                break;

            case "LargeJump":
                rb.AddForce(Vector2.up * 650f);
                animator.SetTrigger("Jump");
                break;

            case "SmallJump":
                rb.AddForce(Vector2.up * 450f);
                animator.SetTrigger("Jump");
                break;
            }
        }
    }
