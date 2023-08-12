using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFoodScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float rottingZone = -15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < rottingZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))

        {
            Destroy(gameObject);
        }
    }

}
