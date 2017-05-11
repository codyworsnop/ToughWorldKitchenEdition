using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialController : MonoBehaviour {

    public Sprite DialOn;
    public Sprite DialOff;
    public List<int> StovesToTurnOff;
    public List<int> StovesToTurnOn;
    public List<int> StovesToToggle;
    public SpriteRenderer DialSprite;


    private AudioSource _dialSound;
    private bool _inRangeOfDial;

    private void Start()
    {
        _inRangeOfDial = false;
        _dialSound = GameObject.Find("DialSound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _inRangeOfDial = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _inRangeOfDial = false;
        }
    }

    public void SetDialOn()
    {
       var dialSprite = DialSprite.GetComponent<SpriteRenderer>();
        dialSprite.sprite = DialOn;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _inRangeOfDial)
        {
            var dialSprite = DialSprite.GetComponent<SpriteRenderer>();
            
            if (dialSprite.sprite == DialOn)
            {
                _dialSound.Play();

                dialSprite.sprite = DialOff;

                foreach (var index in StovesToToggle)
                {
                    GameObject.Find("StovePlates").GetComponent<StoveTopCollectionController>().StoveTops[index].GetComponent<StoveTopBehaviour>().ToggleStove();
                }
            }
            else
            {
                _dialSound.Play();

                dialSprite.sprite = DialOn;

                foreach (var index in StovesToToggle)
                {
                    GameObject.Find("StovePlates").GetComponent<StoveTopCollectionController>().StoveTops[index].GetComponent<StoveTopBehaviour>().ToggleStove();
                }
            }

            foreach (var index in StovesToTurnOff)
            {
                GameObject.Find("StovePlates").GetComponent<StoveTopCollectionController>().StoveTops[index].GetComponent<StoveTopBehaviour>().SetStoveOff();
            }

            foreach (var index in StovesToTurnOn)
            {
                GameObject.Find("StovePlates").GetComponent<StoveTopCollectionController>().StoveTops[index].GetComponent<StoveTopBehaviour>().SetStoveOn();
            }
        }
    }
}
