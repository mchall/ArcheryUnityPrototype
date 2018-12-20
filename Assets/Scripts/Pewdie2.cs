using UnityEngine;
using System.Collections;

public class Pewdie2 : MonoBehaviour
{
    public GameObject trolley;

    Player player;

    float powerTime = -9999;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && (Time.time - powerTime >= 30f))
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