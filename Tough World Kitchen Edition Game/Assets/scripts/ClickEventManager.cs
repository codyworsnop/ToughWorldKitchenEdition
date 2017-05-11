﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickEventManager : MonoBehaviour {

    public string SceneName;
    public Texture2D CursorTexture;
    public bool ChangingScenes;
    public bool IsBossScene; 

    private bool _sceneLoading;

    private void Start()
    {
        _sceneLoading = false;
    }

    private void OnMouseOver()
    {
        if (!_sceneLoading)
        {
            Cursor.SetCursor(CursorTexture, new Vector2(10, 0), CursorMode.ForceSoftware);
        }
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseDown()
    {
        _sceneLoading = true;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        if (ChangingScenes)
        {
            if (!IsBossScene)
            {
                SceneManager.LoadScene(SceneName);
            }
            else if (!(PlayerPrefs.GetInt("Fridge") == 1) || !(PlayerPrefs.GetInt("Stove") == 1))
            {
                SceneManager.LoadScene("blackboardScene");
            }
            else
            {
                SceneManager.LoadScene("bossScene");
            }
        }
    }
}
