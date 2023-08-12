using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraMovementScript : MonoBehaviour
{

    [SerializeField]  private Transform endPos;
    [SerializeField] public float speed = 1f;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, endPos.position, speed * Time.deltaTime);
    }
}
