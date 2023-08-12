using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public enum Type
    {
        Burger,
    }

    public Type type;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))

        {
            Collect(other.gameObject);
            
        }
    }

    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Burger:
                // TODO
                break;
        }

        Destroy(gameObject);
    }
}
