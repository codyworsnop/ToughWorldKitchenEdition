using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveTopBehaviour : MonoBehaviour {

    public Sprite HotSurface;
    public Sprite HotHotSurface;
    public Sprite SurfaceOff;
    public float timeToChange; 

    public SpriteRenderer sprite;
    private float TimeLeft;
    public bool IsStoveOff;

	// Use this for initialization
	void Start () {

        IsStoveOff = false;
        TimeLeft = timeToChange;
    
	}
	
    public void ToggleStove()
    {
        if (IsStoveOff)
        {
            IsStoveOff = false;
        }
        else
        {
            IsStoveOff = true;
        }
    }

    public void SetStoveOff()
    {
        IsStoveOff = true;
    }

    public void SetStoveOn()
    {
        IsStoveOff = false;
    }

	// Update is called once per frame
	void Update () {

        TimeLeft -= Time.deltaTime;

        if (IsStoveOff)
        {
            sprite.sprite = SurfaceOff;
        }
        else if (TimeLeft <= 0) //time up
        {
            //change image
            if (sprite.sprite == HotSurface)
            {
                sprite.sprite = HotHotSurface;
            }
            else
            {
                sprite.sprite = HotSurface;
            }

            TimeLeft = timeToChange;
        }
	}
}
