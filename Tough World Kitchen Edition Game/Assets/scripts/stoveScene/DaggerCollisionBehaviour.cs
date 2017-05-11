using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaggerCollisionBehaviour : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerPrefs.SetInt("Stove", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("main");
        }
    }
}
