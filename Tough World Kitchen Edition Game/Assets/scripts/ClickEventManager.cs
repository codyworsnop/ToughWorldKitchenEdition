using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickEventManager : MonoBehaviour {

    public string SceneName;

    void OnMouseDown()
    {
        SceneManager.LoadScene(SceneName);
    }
}
