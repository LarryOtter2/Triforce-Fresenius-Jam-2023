using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EventSystems;

public class Victory : MonoBehaviour
{

    public GameObject VictoryScreen;
    public GameObject GameOverScreen;

    public bool isWinning;
    public bool isLosing;


    void VictoryUI()
    {
        VictoryScreen.SetActive(true);
        isWinning = true;
        Time.timeScale = 0;
    }

    
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
            VictoryUI();
        }

        
        else
        {
            LosingUI();
        }
        
    }

}
