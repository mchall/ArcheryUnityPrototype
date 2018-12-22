using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class BeastMaster : MonoBehaviour
{
    public GameObject arrow;

    Player player;

    float fireTime;
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

        if ((Input.GetButtonDown("Fire1") || leftTrigger) && (Time.time - fireTime >= 0.5f))
        {
            FireProjectile();
            fireTime = Time.time;
        }

        if ((Input.GetButtonDown("Fire2") || rightTrigger) && (Time.time - powerTime >= 10f))
        {
            StartCoroutine(ActivatePower());
            powerTime = Time.time;
        }
    }

    void FireProjectile()
    {
        var newArrow = Instantiate(arrow);
        newArrow.gameObject.SetActive(true);
        newArrow.transform.position = arrow.transform.position;
        newArrow.transform.rotation = arrow.transform.rotation;

        newArrow.GetComponent<Rigidbody>().velocity = arrow.transform.forward.normalized * 20f;
    }

    IEnumerator ActivatePower()
    {
        player.invisible = true;
        yield return new WaitForSeconds(5f);
        player.invisible = false;
    }
}