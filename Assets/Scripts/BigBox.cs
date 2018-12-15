using UnityEngine;
using System.Collections;

public class BigBox : MonoBehaviour
{
    Rigidbody body;
    Player player;
    bool dead;
    int arrowCount;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (!dead && player != null && !player.invisible && transform.position.y < 1)
        {
            body.transform.LookAt(player.transform.position);
            body.MovePosition(body.position + (body.transform.forward * 0.02f));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            StartCoroutine(Flash());

            player.Score++;
            arrowCount++;

            if (arrowCount >= 3)
            {
                dead = true;

                var force = collision.relativeVelocity * 20;
                body.AddForce(force);

                StartCoroutine(Destroy());
            }
        }
        else if (!dead && collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);

        Destroy(gameObject);
    }

    IEnumerator Flash()
    {
        if (!dead)
        {
            var renderer = GetComponent<Renderer>();

            var original = renderer.material.color;

            renderer.material.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            renderer.material.color = original;
        }
    }
}