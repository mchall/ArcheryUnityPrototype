using UnityEngine;
using System.Collections;

public class PoxArrow : MonoBehaviour
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
        if (collision.gameObject.tag == "Pox")
            return;

        if (!hasCollided)
        {
            hasCollided = true;

            GetComponent<BoxCollider>().enabled = false;
            Destroy(body);

            if (collision.gameObject.tag != "Arrow")
            {
                transform.position = transform.position + (transform.forward / 2);
                transform.SetParent(collision.gameObject.transform);
            }

            StartCoroutine(Decay());

            if (collision.gameObject.tag == "Player")
            {
                Destroy(collision.gameObject);
                FindObjectOfType<Canvas>().GetComponent<Scene>().LoseMenu();
            }
        }
    }

    IEnumerator Decay()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<TrailRenderer>().enabled = false;
    }
}