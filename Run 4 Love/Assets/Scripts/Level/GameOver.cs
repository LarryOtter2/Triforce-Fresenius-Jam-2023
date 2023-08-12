using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverScreen;

    public bool isLosing;


    void LosingUI()
    {
        GameOverScreen.SetActive(true);
        isLosing = true;
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            LosingUI();
        }
    }
}
