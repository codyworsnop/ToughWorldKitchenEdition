using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHealthController : MonoBehaviour {

    public int HealthAmount;

    private AudioSource _bossHitSound;

    // Use this for initialization
    private void Start()
    {
        _bossHitSound = GameObject.Find("BossHitSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetHealth(int amount)
    {
        HealthAmount -= amount;

        GameObject.Find("BossHealth").GetComponent<Text>().text = "Boss HP: " + HealthAmount;
    }

    public int GetHealth()
    {
        return HealthAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var isAttacking = GameObject.Find("Letters").GetComponent<DamageController>()._IsLemonAttacking;

        if (isAttacking)
        {
            _bossHitSound.Play();

            SetHealth(10);

            if (GetHealth() == 0)
            {
                SceneManager.LoadScene("lemonWinsScene");
            }
        }
    }
}
