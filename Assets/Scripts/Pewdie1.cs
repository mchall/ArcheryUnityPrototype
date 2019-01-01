using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Pewdie1 : MonoBehaviour
{
    public GameObject laser1;
    public GameObject laser2;
    public SimpleHealthBar healthBar;
    public GameObject chair;
    public GameObject pewdie;

    Player player;

    bool left;
    float fireTime;
    float powerTime = -9999f;
    AudioHelper audioHelper;

    void Start()
    {
        player = FindObjectOfType<Player>();
        audioHelper = Camera.main.GetComponent<AudioHelper>();
    }

    void Update()
    {
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY
        var h2 = player.rightController.GetTouchPosition.x;
        var v2 = player.rightController.GetTouchPosition.y;
        var lookTo = new Vector3(h2, 0, v2);
        if (lookTo.sqrMagnitude > 0.2f && Time.time - fireTime >= 0.2f)
        {
            FireProjectile();
            fireTime = Time.time;
        }
#else
        var leftTrigger = false;
        var rightTrigger = false;

        if (GamePad.GetState(PlayerIndex.One).IsConnected)
        {
            leftTrigger = GamePad.GetState(PlayerIndex.One).Triggers.Left > 0f;
            rightTrigger = GamePad.GetState(PlayerIndex.One).Triggers.Right > 0f;
        }

        if ((Input.GetButtonDown("Fire1") || leftTrigger) && (Time.time - fireTime >= 0.1f))
        {
            FireProjectile();
            fireTime = Time.time;
        }

        if ((Input.GetButtonDown("Fire2") || rightTrigger) && (Time.time - powerTime >= 30f))
        {
            StartCoroutine(ActivatePower());
            powerTime = Time.time;
        }
#endif

            var power = Time.time - powerTime;
        if (power < 0)
            power = 0;
        if (power > 30f)
            power = 30f;
        healthBar.UpdateBar(power, 30f);
    }

    void FireProjectile()
    {
        if (player.invincible)
            return;

        if (audioHelper != null)
            audioHelper.Laser();

        if (left)
        {
            var leftLaser = Instantiate(laser1);
            leftLaser.gameObject.SetActive(true);
            leftLaser.transform.position = laser1.transform.position;
            leftLaser.transform.rotation = laser1.transform.rotation;

            leftLaser.GetComponent<Rigidbody>().velocity = laser1.transform.forward.normalized * 10f;

            left = false;
        }
        else
        {
            var rightLaser = Instantiate(laser2);
            rightLaser.gameObject.SetActive(true);
            rightLaser.transform.position = laser2.transform.position;
            rightLaser.transform.rotation = laser2.transform.rotation;

            rightLaser.GetComponent<Rigidbody>().velocity = laser2.transform.forward.normalized * 10f;

            left = true;
        }
    }

    IEnumerator ActivatePower()
    {
        player.invincible = true;
        pewdie.SetActive(false);
        chair.SetActive(true);
        yield return new WaitForSeconds(5f);
        player.invincible = false;
        chair.SetActive(false);
        pewdie.SetActive(true);
    }
}