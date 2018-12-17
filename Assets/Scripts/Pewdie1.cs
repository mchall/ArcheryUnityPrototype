using UnityEngine;
using System.Collections;

public class Pewdie1 : MonoBehaviour
{
    public GameObject laser1;
    public GameObject laser2;

    Player player;

    bool left;
    float fireTime;
    float powerTime = -9999;

    void Start()
    {
        player = FindObjectOfType<Player>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (Time.time - fireTime >= 0.1f))
        {
            FireProjectile();
            fireTime = Time.time;
        }

        /*if (Input.GetButtonDown("Fire2") && (Time.time - powerTime >= 10f))
        {
            StartCoroutine(ActivatePower());
            powerTime = Time.time;
        }*/
    }

    void FireProjectile()
    {
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
        player.invisible = true;
        yield return new WaitForSeconds(5f);
        player.invisible = false;
    }
}