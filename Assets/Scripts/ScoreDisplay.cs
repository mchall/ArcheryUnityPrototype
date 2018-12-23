using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Player player;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (player == null)
            player = FindObjectOfType<Player>();

        if (player != null)
            text.text = "Score: " + UserData.Instance.CurrentScore.ToString().Replace('0', 'o');
    }
}