using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        StartCoroutine(Decay());
    }

    void Update()
    {
        body.MovePosition(body.position + (body.transform.forward * 0.15f));
    }

    void OnCollisionEnter(Collision collision)
    {
    }

    IEnumerator Decay()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
}