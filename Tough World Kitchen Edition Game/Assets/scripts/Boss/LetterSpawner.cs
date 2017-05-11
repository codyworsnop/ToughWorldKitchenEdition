using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{

    public List<GameObject> Letters;
    public List<Sprite> LetterImages;
    public List<KeyCode> Keycodes;

    public bool StartGame;
    public float TimeToType;

    private Dictionary<KeyCode, Sprite> LetterDictionary;
    private float _timeLeft;
    private int _letterIndex;
    private DamageController _damageController;
    private bool _puzzleSolved;

    // Use this for initialization
    void Start()
    {

        LetterDictionary = new Dictionary<KeyCode, Sprite>();
        _timeLeft = TimeToType;
        _letterIndex = 0;
        _damageController = GetComponent<DamageController>();
        _puzzleSolved = false;
        StartGame = false;

        var keycodeIndex = 0;

        foreach (var letter in LetterImages)
        {
            LetterDictionary.Add(Keycodes[keycodeIndex], letter);
            keycodeIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StartGame)
        {
            if (_timeLeft <= 0)
            {
                //pick random letters
                foreach (var letter in Letters)
                {
                    var rand = Random.Range(0, 25);
                    letter.GetComponent<SpriteRenderer>().sprite = LetterImages[rand];
                }

                _timeLeft = TimeToType;
                _letterIndex = 0;
                _damageController.IsAttacking = false;

                if (!_puzzleSolved)
                {
                    _damageController.AttackLemon();
                }

                _puzzleSolved = false;
            }

            Sprite valueOut;
            LetterDictionary.TryGetValue(FetchKey(), out valueOut);
       
            if (!_damageController.IsAttacking && !_puzzleSolved)
            {
                if (valueOut == Letters[_letterIndex].GetComponent<SpriteRenderer>().sprite)
                {
                    Debug.Log("letter found");
                    Letters[_letterIndex].GetComponent<SpriteRenderer>().sprite = null;
                    _letterIndex++;

                    if (_letterIndex > 3)
                    {
                        //do cookie damage
                        _damageController.AttackBoss();
                        _puzzleSolved = true;
                        _letterIndex = 0;
                    }
                }
            }

            _timeLeft -= Time.deltaTime;
        }
    }

    private KeyCode FetchKey()
    {
        var e = System.Enum.GetNames(typeof(KeyCode)).Length;

        for (int i = 0; i < e; i++)
        {
            if (Input.GetKeyDown((KeyCode)i))
            {
                return (KeyCode)i;
            }
        }

        return KeyCode.None;
    }
}
