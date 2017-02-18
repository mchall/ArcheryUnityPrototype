using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    Rigidbody body;
    bool hasCollided;

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

        if (!hasCollided)
        {
            hasCollided = true;

            GetComponent<BoxCollider>().enabled = false;
            Destroy(body);

            transform.position = transform.position + (transform.forward / 2);
            transform.SetParent(collision.gameObject.transform);

            StartCoroutine(Decay());
        }
    }

    IEnumerator Decay()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<TrailRenderer>().enabled = false;
    }
}