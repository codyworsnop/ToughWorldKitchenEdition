using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveFridge : MonoBehaviour {

    private Rigidbody2D _rigid2d;
	// Use this for initialization
	void Start ()
    {
        _rigid2d = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _rigid2d.AddForce(new Vector2(0, 50));
        }
    }
}
