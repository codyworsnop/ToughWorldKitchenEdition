using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCollision : MonoBehaviour {

    private AudioSource hitSound;
    private StoveTopBehaviour _stoveStop;

    private void Start()
    {
        hitSound = GameObject.Find("HitSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _stoveStop = GetComponent<StoveTopBehaviour>();

        if (collision.tag == "Player" && !_stoveStop.IsStoveOff)
        {
            var currentHealth = GameObject.Find("Player").GetComponent<playerHealthStove>().GetHealth();
            GameObject.Find("Player").GetComponent<playerHealthStove>().SetHealth(currentHealth - 10);

            CheckForDeath();
            hitSound.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _stoveStop = GetComponent<StoveTopBehaviour>();

        if (collision.tag == "Player" && !_stoveStop.IsStoveOff)
        {
            var currentHealth = GameObject.Find("Player").GetComponent<playerHealthStove>().GetHealth();
            GameObject.Find("Player").GetComponent<playerHealthStove>().SetHealth(currentHealth - 5);

            CheckForDeath();
            
        }
    }

    private void CheckForDeath()
    {
        var currentHealth = GameObject.Find("Player").GetComponent<playerHealthStove>().GetHealth();

        if (currentHealth <= 0)
        {
            GameObject.Find("Player").transform.position = new Vector3(-4.5f, -3.5f, -1);
            GameObject.Find("Player").GetComponent<playerHealthStove>().SetHealth(100);

            //reset all burners and dials
            var dials = GameObject.FindGameObjectsWithTag("Dial");

            foreach (var dial in dials)
            {
                dial.GetComponent<DialController>().SetDialOn();
            }

            var stoves = GameObject.Find("StovePlates");
            var stove = stoves.GetComponent<StoveTopCollectionController>().StoveTops;

            foreach (var stovetop in stove)
            {
                stovetop.GetComponent<StoveTopBehaviour>().SetStoveOn();
            }
        }
    }
}
