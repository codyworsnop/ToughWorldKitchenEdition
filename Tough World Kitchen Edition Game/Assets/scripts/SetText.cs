using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

    private Text text;

	// Use this for initialization
	void Start () {
        text = GameObject.Find("Table").GetComponent<Text>();
        text.text = PlayerPrefs.GetString("Table", "Traverse the kitchen table to obtain The Butter Dagger of Justice");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
