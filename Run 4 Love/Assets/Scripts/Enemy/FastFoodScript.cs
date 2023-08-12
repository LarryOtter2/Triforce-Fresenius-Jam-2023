using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFoodScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float rottingZone = -15;





    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

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
                playerMovement.ApplySlowdown();
                Destroy(gameObject);
            }

        }

    }
}
