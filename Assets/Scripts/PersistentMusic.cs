using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentMusic : MonoBehaviour
{

    // background music plays on a loop at start of main menu and never stops between levels

    static GameObject instance;

    void Start()
    {
        if (instance == null)
        {

            instance = gameObject;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}