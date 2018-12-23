using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XInputDotNetPure;

public class Menu : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;

    void Start()
    {
        AspectTweak();

        text1.text = "high score \n" + UserData.Instance.PewdieScore.ToString().Replace('0', 'o');
        text2.text = "high score \n" + UserData.Instance.BeastMasterScore.ToString().Replace('0', 'o');
        text3.text = "high score \n" + UserData.Instance.TrolleyScore.ToString().Replace('0', 'o');
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

    public void Play1()
    {
        UserData.Instance.CurrentCharacter = 1;
        SceneManager.LoadScene("Game");
    }

    public void Play2()
    {
        UserData.Instance.CurrentCharacter = 2;
        SceneManager.LoadScene("Game");
    }

    public void Play3()
    {
        UserData.Instance.CurrentCharacter = 3;
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}