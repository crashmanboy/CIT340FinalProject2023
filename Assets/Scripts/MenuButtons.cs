using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play(string levelName)
    {

        SceneManager.LoadScene("LevelOne");

    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }

    public void Continue()
    {

    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
