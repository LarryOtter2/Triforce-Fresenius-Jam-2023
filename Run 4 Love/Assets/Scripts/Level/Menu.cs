using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [Header("MainMenu")]
    public GameObject MainM;
    public bool inMainM;

    [Header("PauseMenu")]
    public GameObject PauseM;
    public bool inPauseM;

    
    [SerializeField] Victory victoryScreen;

    [SerializeField] GameOver losingScreen;


    void Awake()
    {
        MainMenu();
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        OnEsc();

        if (inMainM == true || inPauseM == true || victoryScreen.isWinning == true || losingScreen.isLosing == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

    }


    public void MainMenu()
    {
        Time.timeScale = 0;
        MainM.SetActive(true);
        inMainM = true;
    }

    public void CloseMainMenu()
    {
        Time.timeScale = 1;
        MainM.SetActive(false);
        inMainM = false;
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        PauseM.SetActive(true);
        inPauseM = true;
    }
    public void ClosePauseMenu()
    {
        Time.timeScale = 1;
        PauseM.SetActive(false);
        inPauseM = false;
    }


    //Buttons 
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Reset()
    {
        SceneManager.LoadScene("P 1");
    }

    //Esc
    public void OnEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !victoryScreen.isWinning && !losingScreen.isLosing)
        {
            

            if (inPauseM == false && inMainM == false)
            {
                //Debug.Log("PauseMenu");
                PauseMenu();
            }

            else if (inPauseM == true)
            {
                /*Debug.Log("CloseSettings");*/
                ClosePauseMenu();
            }
        }
    }


}
