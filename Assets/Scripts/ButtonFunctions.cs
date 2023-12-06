using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    //operates buttions for main menu

    public void Play(string levelName)
    {

        SceneManager.LoadScene("LevelOne");

    }
    public void Credits(string levelName)
    {
        SceneManager.LoadScene("CreditsScene");
    }
    
    public void ContinueGame()
    {
        string Level = PlayerPrefs.GetString("Last Level", "LevelOne");
        SceneManager.LoadScene(Level);

    }
   
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }
}
