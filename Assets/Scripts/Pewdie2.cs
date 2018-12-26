using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Pewdie2 : MonoBehaviour
{
    public SimpleHealthBar healthBar;

    Player player;
    AudioHelper audioHelper;
    TrolleyAnimator trolley;
    Quaternion rotation;

    float powerTime= -9999f;

    void Start()
    {
        player = FindObjectOfType<Player>();
        audioHelper = Camera.main.GetComponent<AudioHelper>();
        trolley = GetComponentInChildren<TrolleyAnimator>();
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
        rotation = trolley.gameObject.transform.rotation;

        trolley.enabled = true;
        player.invincible = true;
        yield return new WaitForSeconds(5f);
        player.invincible = false;
        trolley.enabled = false;

        trolley.gameObject.transform.rotation = rotation;
    }
}