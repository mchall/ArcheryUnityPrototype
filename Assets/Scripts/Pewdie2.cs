using UnityEngine;
using System.Collections;

public class Pewdie2 : MonoBehaviour
{
    Player player;

    float powerTime = -9999;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && (Time.time - powerTime >= 5f))
        {
            StartCoroutine(ActivatePower());
            powerTime = Time.time;
        }
    }

    IEnumerator ActivatePower()
    { 
        //todo
        yield return new WaitForSeconds(1f);
    }
}