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
    public Image cross;

    Transform focusedControl;

    void Start()
    {
        AspectTweak();

        if (text1 != null)
            text1.text = "high score \n" + UserData.Instance.PewdieScore.ToString().Replace('0', 'o');
        if (text2 != null)
            text2.text = "high score \n" + UserData.Instance.BeastMasterScore.ToString().Replace('0', 'o');
        if (text3 != null)
            text3.text = "high score \n" + UserData.Instance.TrolleyScore.ToString().Replace('0', 'o');

        if(cross != null && UserData.Instance.MusicOff)
            cross.gameObject.SetActive(true);
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

    public void OnMouseHover()
    {
        PointerEventData pe = new PointerEventData(EventSystem.current);
        pe.position = Input.mousePosition;

        List<RaycastResult> hits = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pe, hits);
        foreach (RaycastResult h in hits)
        {
            if (h.gameObject != null && h.gameObject.GetComponent<Button>() != null)
            {
                FocusControl(h.gameObject.transform);
                break;
            }
        }
    }

    private void FocusControl(Transform control)
    {
        if (control.name == "Left" || control.name == "Right")
            return;

        if (focusedControl != null)
        {
            focusedControl.transform.localScale = new Vector3(1, 1, 1);
        }

        focusedControl = control;
        EventSystem.current.SetSelectedGameObject(focusedControl.gameObject);

        control.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
    }

    public void ToggleMusic()
    {
        UserData.Instance.MusicOff = !UserData.Instance.MusicOff;
        cross.gameObject.SetActive(UserData.Instance.MusicOff);
        MusicPlayer.Instance.PlayGameMusic();
    }

    public void Back()
    {
        SceneManager.LoadScene("Main");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
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