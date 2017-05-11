using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private Rigidbody2D _rigid2d;

	// Use this for initialization
	void Start () {
        _rigid2d = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate()
    {
        

        if (Input.GetKey(KeyCode.UpArrow) && Input.anyKey)
        {
            _rigid2d.velocity = new Vector2(0, 2);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.anyKey)
        {
            _rigid2d.velocity = new Vector2(0, -2);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.anyKey)
        {
            _rigid2d.velocity = new Vector2(-2, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.anyKey)
        {
            _rigid2d.velocity = new Vector2(2, 0);
        }
        else
        {
            _rigid2d.velocity = new Vector2(0, 0);
        }

    }
}
