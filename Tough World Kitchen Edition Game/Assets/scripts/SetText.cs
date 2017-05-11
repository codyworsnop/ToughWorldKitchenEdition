using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

    private Text text;

	// Use this for initialization
	void Start () {

        text = GameObject.Find("Fridge").GetComponent<Text>();

        if (PlayerPrefs.GetInt("Fridge") == 1)
        {
            text.text = GlobalStrings.FridgeInstructionStrikeThrough;
        }
        else
        {
            text.text = GlobalStrings.FridgeInstruction;
        }

        text = GameObject.Find("Stove").GetComponent<Text>();

        if (PlayerPrefs.GetInt("Stove") == 1)
        {
            text.text = GlobalStrings.StoveInstructionStrikeThrough;
        }
        else
        {
            text.text = GlobalStrings.StoveInstruction;
        }

        text = GameObject.Find("Boss").GetComponent<Text>();

        if (PlayerPrefs.GetInt("Boss") == 1)
        {
            text.text = GlobalStrings.CookieInstructionStrikeThrough;
        }
        else
        {
            text.text = GlobalStrings.CookieInstruction;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
