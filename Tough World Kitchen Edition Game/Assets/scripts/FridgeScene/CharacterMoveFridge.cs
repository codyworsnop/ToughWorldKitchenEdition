using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveFridge : MonoBehaviour
{
    private Rigidbody2D _rigid2d;
    private bool _grounded = false;
    private bool startEnemies = false;
    private Quaternion _defaultRotation;
    public float TimeLength;
    private float _timeLeft;
    private AudioSource _jumpSound;

    public GameObject FallingCookie;

    // Use this for initialization
    void Start()
    {
        _rigid2d = GetComponent<Rigidbody2D>();
        _defaultRotation = transform.rotation;
        _timeLeft = TimeLength;
        _jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow) && _grounded)
        {
            startEnemies = true;
            _rigid2d.AddForce(new Vector2(0, 500));
            _grounded = false;

            _jumpSound.Play();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rigid2d.AddForce(new Vector2(10, 0));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rigid2d.AddForce(new Vector2(-10, 0));
        }
    }

    private void Update()
    {       
        if (startEnemies)
        {
            _timeLeft -= Time.deltaTime;

            if (_timeLeft <= 0)
            {
                //spawn new enemy
                Instantiate(FallingCookie, new Vector3(transform.position.x, transform.position.y + 20, transform.position.z), transform.rotation);
                _timeLeft = TimeLength;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(_rigid2d.velocity.y) < 5)
        {
            _grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _grounded = false;
    }
}
