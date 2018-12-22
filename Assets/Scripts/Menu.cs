using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XInputDotNetPure;

public class Menu : MonoBehaviour
{
    void Start()
    {
        AspectTweak();
    }

    void Update()
    {
    }

    void AspectTweak()
    {
        if (Camera.main.aspect >= 1.7)
            Camera.main.orthographicSize = 9;
        else if (Camera.main.aspect >= 1.6)
            Camera.main.orthographicSize = 10;
        else if (Camera.main.aspect >= 1.5)
            Camera.main.orthographicSize = 11;
        else if (Camera.main.aspect >= 1.3)
            Camera.main.orthographicSize = 12;
        else
            Camera.main.orthographicSize = 13;
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}