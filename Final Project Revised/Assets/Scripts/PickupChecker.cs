using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupChecker : MonoBehaviour
{ // Start is called before the first frame update
    static GameObject instance;
    public TMP_Text pickupText;
    public float beginningPickupNumber;
    public static float currentPickupNumber;

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

        


    }

    // Update is called once per frame
    void Update()
    {
        currentPickupNumber = beginningPickupNumber + currentPickupNumber;
        pickupText.text = "Pickups Collected: " + currentPickupNumber.ToString();

    }
    void checkScene(Scene currentScene, Scene nextScene)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            currentPickupNumber = 0;
            Destroy(gameObject);
        }
    }
}

