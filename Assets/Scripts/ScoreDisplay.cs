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
        player = FindObjectOfType<Player>();
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (player != null)
            text.text = "Score: " + player.Score.ToString();
    }
}