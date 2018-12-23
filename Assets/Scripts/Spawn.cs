using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject char1;
    public GameObject char2;
    public GameObject char3;

    void Start()
    {
        UserData.Instance.CurrentScore = 0;
        switch (UserData.Instance.CurrentCharacter)
        {
            case 1:
                char1.SetActive(true);
                break;
            case 2:
                char2.SetActive(true);
                break;
            case 3:
                char3.SetActive(true);
                break;
            default:
                char1.SetActive(true);
                break;
        }
    }
}