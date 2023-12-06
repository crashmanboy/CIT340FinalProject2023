using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    //script for time of life that an object or sound has in game


    public float timeToLive = 3f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Invoke("soundLife", timeToLive);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void soundLife()
    {
        Destroy(gameObject);
    }
}

