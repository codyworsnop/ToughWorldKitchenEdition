using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthStove : MonoBehaviour {

    public int HealthAmount;

    private int _health;
    
    private void Start()
    {
        _health = HealthAmount;    
    }

    public void SetHealth(int amount)
    {
        _health = amount;

        GameObject.Find("Health").GetComponent<Text>().text = "Health: " + _health;
    }

    public int GetHealth()
    {
        return _health; 
    }
}
