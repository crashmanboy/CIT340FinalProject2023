using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    //operates the timer in the game levels which does not reset after beating level one and only resets after beating the whole game and returning to the main menu

    //also syncs to timer text


    // Start is called before the first frame update
    static GameObject instance;
    public TMP_Text timerText;
    public float beginningTime;
    public static float currentTime;

    void Start()
    {
        if (instance == null)
        {

            instance = gameObject;
            SceneManager.activeSceneChanged += checkScene;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        beginningTime = Time.time;


    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time - beginningTime;
        timerText.text = "Time Elapsed: " + currentTime.ToString();

    }
    void checkScene(Scene currentScene, Scene nextScene)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }
}

