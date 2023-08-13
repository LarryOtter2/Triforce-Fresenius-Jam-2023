using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFoodScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float rottingZone = -15;

    
    private EnemyMovement enemyMovement;

    private int moveDirection; // 1 for moving left, -1 for moving right

    

    void Update()
    {
        transform.position = transform.position + (Vector3.right * moveSpeed * moveDirection) * Time.deltaTime;

        if (enemyMovement.inFront == true)
        {
            moveDirection = 1; // Set moveDirection to -1 if inFront is true
        }
        else { moveDirection = -1; }

        if (transform.position.x < rottingZone)
        {
            Destroy(gameObject);
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))

        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.ExtendFatTimer();
                playerMovement.ApplySlowdown();
                Destroy(gameObject);
            }

        }

    }

    public void Instantiated(EnemyMovement x)
    {
        enemyMovement = x;
    }
}
