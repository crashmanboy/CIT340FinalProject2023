using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLevel : MonoBehaviour
{


    //operates pause menu on levels

    private bool isPaused = false;
    private bool clickReleased = true;
    

    public GameObject pausePanel;
    public void Pause(bool isPaused)
    {
        Time.timeScale = isPaused ? 0.0f : 1.0f;
        pausePanel.SetActive(isPaused);
    }


    public void Continue()
    {

        isPaused = false;
        Pause(isPaused);
    }

   
    public void MainMenu(string levelName)
    {

        PlayerPrefs.SetString("Last Level", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainMenu");

       
    }

    public void Start()
    {
        Continue();
    }
    void Update()
    {
        bool pauseClicked = Input.GetAxisRaw("Pause") == 1;
        if (!pauseClicked)
        {
            clickReleased = true;
        }
        else if (pauseClicked && clickReleased)
        {
            isPaused = !isPaused;
            clickReleased = false;
            Pause(isPaused);
        }
    }
}
