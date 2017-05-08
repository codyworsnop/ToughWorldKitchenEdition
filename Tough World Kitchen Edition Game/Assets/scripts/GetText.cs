using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetText : MonoBehaviour {


    // Use this for initialization
    void Start () {
        PlayerPrefs.SetString("Table", "T̶r̶a̶v̶e̶r̶s̶e̶ ̶t̶h̶e̶ ̶k̶i̶t̶c̶h̶e̶n̶ ̶t̶a̶b̶l̶e̶ ̶t̶o̶ ̶o̶b̶t̶a̶i̶n̶ ̶T̶h̶e̶ ̶B̶u̶t̶t̶e̶r̶ ̶D̶a̶g̶g̶e̶r̶ ̶o̶f̶ ̶J̶u̶s̶t̶i̶c̶e̶");
        //PlayerPrefs.SetString("Table", "Traverse the kitchen table to obtain The Butter Dagger of Justice");
        PlayerPrefs.Save();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
