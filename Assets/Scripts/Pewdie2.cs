using UnityEngine;
using System.Collections;

public class Pewdie2 : MonoBehaviour
{
    Rigidbody body;

    float powerTime = -9999;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        /*if (Input.GetButtonDown("Fire1") && (Time.time - fireTime >= 0.1f))
        {
            FireProjectile();
            fireTime = Time.time;
        }*/

        if (Input.GetButtonDown("Fire2") && (Time.time - powerTime >= 5f))
        {
            //body.AddForce(body.transform.forward * 100000f);
            //powerTime = Time.time;

            body.AddRelativeForce(body.transform.up * 1000f, ForceMode.Impulse);

            Debug.Log("hello");
        }
    }
}