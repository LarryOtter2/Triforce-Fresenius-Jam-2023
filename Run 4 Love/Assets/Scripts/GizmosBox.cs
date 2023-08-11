using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosBox : MonoBehaviour
{
    [SerializeField] BoxCollider2D Collider;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(Collider.bounds.center, Collider.bounds.size);
    }


}
