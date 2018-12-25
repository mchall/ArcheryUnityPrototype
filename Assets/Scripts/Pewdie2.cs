using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Pewdie2 : MonoBehaviour
{
    public GameObject trolley;
    public SimpleHealthBar healthBar;

    Player player;
    AudioHelper audioHelper;

    float powerTime= -9999f;

    void Start()
    {
        player = FindObjectOfType<Player>();
        audioHelper = Camera.main.GetComponent<AudioHelper>();
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

        var power = Time.time - powerTime;
        if (power < 0)
            power = 0;
        if (power > 30f)
            power = 30f;
        healthBar.UpdateBar(power, 30f);
    }

    IEnumerator ActivatePower()
    {
        player.invincible = true;
        player.superSpeed = true;
        yield return new WaitForSeconds(5f);
        player.superSpeed = false;
        player.invincible = false;
    }
}