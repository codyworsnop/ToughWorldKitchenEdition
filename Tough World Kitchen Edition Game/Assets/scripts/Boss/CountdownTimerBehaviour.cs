using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimerBehaviour : MonoBehaviour {

    public float timeBeforeStart = 5.0f;

    private float _timeLeft;
    private Text _timerText; 
     
	// Use this for initialization
	void Start () {
        _timeLeft = timeBeforeStart;
        _timerText = GameObject.Find("CountdownToStart").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!GetComponent<LetterSpawner>().StartGame)
        {
            _timeLeft -= Time.deltaTime;

            if (_timeLeft <= 0)
            {
                _timeLeft = timeBeforeStart;
                GetComponent<LetterSpawner>().StartGame = true;
                _timerText.text = "";

                var letterSpawner = GetComponent<LetterSpawner>();
                //pick random letters
                foreach (var letter in letterSpawner.Letters)
                {
                    var rand = Random.Range(0, 25);
                    letter.GetComponent<SpriteRenderer>().sprite = letterSpawner.LetterImages[rand];
                }
            }
            else if (_timeLeft < 4.0f)
            {
                _timerText.text = "" + _timeLeft;
            }
        }
	}
}
