using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int HealthAmount; 
    public GameObject FallingCookieType;

	public void SetHealth(int amount)
    {
        HealthAmount = amount;
        GameObject.Find("Health").GetComponent<Text>().text = "Health: " + amount;
        
        if (HealthAmount == 0)
        {
            //game over
            transform.position = new Vector3(0, 0, -1);
            HealthAmount = 100;
            GameObject.Find("Health").GetComponent<Text>().text = "Health: " + 100;

            var cookies = GameObject.FindGameObjectsWithTag("Cookie");
            foreach (var cookie in cookies)
            {
                Destroy(cookie);
            }

        } 
    }
}
