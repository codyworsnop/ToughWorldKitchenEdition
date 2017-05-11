using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAll : MonoBehaviour {

    private void Start()
    {
        PlayerPrefs.SetInt("Fridge", 0);
        PlayerPrefs.SetInt("Stove", 0);
        PlayerPrefs.SetInt("Boss", 0);
    }
}
