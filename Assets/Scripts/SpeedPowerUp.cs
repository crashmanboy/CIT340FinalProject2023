using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPowerUp : MonoBehaviour
{


    // script for speed power up making player run faster

    public AudioSource sound;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            sound.Play();
            player.speedPerSecond = 500;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            Invoke("Kill", 3f);
            PersistentValues.currentPickupNumber++;
        }


    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}