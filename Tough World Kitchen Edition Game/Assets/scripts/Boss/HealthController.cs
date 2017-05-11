using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public int HealthAmount;

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetBossHealth(int amount)
    {
        HealthAmount -= amount;

        GetComponent<Text>().text = "Tough Lemon HP: " + HealthAmount;
    }
}
