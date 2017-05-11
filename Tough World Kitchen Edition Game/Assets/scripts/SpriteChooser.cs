using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChooser : MonoBehaviour {

    public Sprite LemonWithHelmet;
    public Sprite LemonWithKnife;
    public Sprite LemonWithKnifeAndHelmet;
    public Sprite LemonDefault;

    public SpriteRenderer SpriteRenderer;

    // Use this for initialization
    void Start () {

        if (PlayerPrefs.GetInt("Fridge") == 1 && PlayerPrefs.GetInt("Stove") == 1)
        {
            SpriteRenderer.sprite = LemonWithKnifeAndHelmet;
        }
        else if (PlayerPrefs.GetInt("Fridge") == 1)
        {
            SpriteRenderer.sprite = LemonWithHelmet;
        }
        else if (PlayerPrefs.GetInt("Stove") == 1)
        {
            SpriteRenderer.sprite = LemonWithKnife;
        }
        else
        {
            SpriteRenderer.sprite = LemonDefault;
        }
  
    }

}
