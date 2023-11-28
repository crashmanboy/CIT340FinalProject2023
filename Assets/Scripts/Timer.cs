using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
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

