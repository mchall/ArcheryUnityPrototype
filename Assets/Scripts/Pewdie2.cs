using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Pewdie2 : MonoBehaviour
{
    public GameObject trolley;

    Player player;

    float powerTime;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        var leftTrigger = false;
        var rightTrigger = false;

        if (GamePad.GetState(PlayerIndex.One).IsConnected)
        {
            leftTrigger = GamePad.GetState(PlayerIndex.One).Triggers.Left > 0f;
            rightTrigger = GamePad.GetState(PlayerIndex.One).Triggers.Right > 0f;
        }

        if ((Input.GetButtonDown("Fire2") || rightTrigger) && (Time.time - powerTime >= 30f))
        {
            StartCoroutine(ActivatePower());
            powerTime = Time.time;
        }
    }

    IEnumerator ActivatePower()
    {
        trolley.tag = "Arrow";
        yield return new WaitForSeconds(5f);
        trolley.tag = "Trolley";
    }
}