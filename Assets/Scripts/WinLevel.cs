using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{

    // sound plays when you win level and loads the next scene after that level


    public GameObject soundEffect2;
    public string levelName;

    public void OnTriggerEnter2D(Collider2D collision)
    {




        if (collision.transform.tag == "Player")
        {

            Debug.Log("You win!");
            GameObject sound = Instantiate(soundEffect2);
            GameObject.DontDestroyOnLoad(sound);
            SceneManager.LoadScene(levelName);



        }

    }

}
