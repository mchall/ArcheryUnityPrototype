using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (body != null)
            transform.LookAt(transform.position + body.velocity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            return;

        GetComponent<TrailRenderer>().enabled = false;
        Destroy(this.gameObject);
    }
}