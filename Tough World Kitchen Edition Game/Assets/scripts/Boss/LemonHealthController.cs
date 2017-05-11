using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LemonHealthController : MonoBehaviour
{

    public int HealthAmount;

    private AudioSource _lemonHitSound;

    // Use this for initialization
    void Start()
    {
        _lemonHitSound = GameObject.Find("LemonHitSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHealth(int amount)
    {
        HealthAmount -= amount;

        GameObject.Find("LemonHealth").GetComponent<Text>().text = "Tough Lemon HP: " + HealthAmount;
    }

    public int GetHealth()
    {
        return HealthAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var isAttacking = GameObject.Find("Letters").GetComponent<DamageController>()._IsBossAttacking;

        if (isAttacking)
        {
            _lemonHitSound.Play();

            SetHealth(25);

            if (GetHealth() == 0)
            {
                SceneManager.LoadScene("bossWinsScene");
            }
        }
    }
}
