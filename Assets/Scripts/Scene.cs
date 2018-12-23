using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using XInputDotNetPure;

public class Scene : MonoBehaviour
{
    Transform gameMenu;

    void Start()
    {
        gameMenu = transform.Find("GameMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Back Button"))
        {
            gameMenu.gameObject.SetActive(!gameMenu.gameObject.activeInHierarchy);
        }
        else
        {
            if (gameMenu.gameObject.activeInHierarchy)
            {
                if (gameMenu.gameObject.activeInHierarchy)
                {
                    if (Input.GetButtonDown("Y Button") || Input.GetButtonDown("Replay"))
                    {
                        SceneReset();
                    }
                    if (Input.GetButtonDown("B Button"))
                    {
                        Home();
                    }
                }
            }
        }
    }

    public void SceneReset()
    {
        SceneManager.LoadScene("Game");
    }

    public void Home()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoseMenu()
    {
        if (gameMenu.gameObject.activeInHierarchy)
            return;

        switch (UserData.Instance.CurrentCharacter)
        {
            case 1:
                if (UserData.Instance.CurrentScore > UserData.Instance.PewdieScore)
                    UserData.Instance.PewdieScore = UserData.Instance.CurrentScore;
                break;
            case 2:
                if (UserData.Instance.CurrentScore > UserData.Instance.BeastMasterScore)
                    UserData.Instance.BeastMasterScore = UserData.Instance.CurrentScore;
                break;
            case 3:
                if (UserData.Instance.CurrentScore > UserData.Instance.TrolleyScore)
                    UserData.Instance.TrolleyScore = UserData.Instance.CurrentScore;
                break;
            default:
                UserData.Instance.PewdieScore = UserData.Instance.CurrentScore;
                break;
        }

        StartCoroutine(DoShowCanvas(1f));
    }

    IEnumerator DoShowCanvas(float time)
    {
        yield return new WaitForSeconds(time);
        gameMenu.gameObject.SetActive(true);
    }
}