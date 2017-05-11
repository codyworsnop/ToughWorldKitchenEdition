using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCookieBehavior : MonoBehaviour {

    public Sprite[] cookies;
    public GameObject CookieObject;

    private AudioSource hitSound;

	// Use this for initialization
	void Start () {

        //choose random image
        int rand = Random.Range(1, 6);
        Debug.Log(rand);
        CookieObject.GetComponent<SpriteRenderer>().sprite = cookies[rand];

        hitSound = GameObject.Find("HitSound").GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Hit Character");
            var health = GameObject.Find("Character").GetComponent<Health>().HealthAmount;
            GameObject.Find("Character").GetComponent<Health>().SetHealth(health - 25);

            hitSound.Play();

            Destroy(gameObject);
        }
        else if (collision.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
