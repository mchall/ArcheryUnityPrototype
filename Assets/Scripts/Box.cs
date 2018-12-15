using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{
    public Material flash;

    Rigidbody body;
    Player player;
    bool dead;

    Vector3 lastPos;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (!dead && player != null && !player.invisible && transform.position.y < 1)
        {
            lastPos = player.transform.position;
            GetComponentInChildren<BodyAnimator>().enabled = true;

            body.transform.LookAt(player.transform.position);
            body.MovePosition(body.position + (body.transform.forward * 0.06f));
        }
        else if (!dead)
        {
            GetComponentInChildren<BodyAnimator>().enabled = false;
            body.transform.LookAt(lastPos);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            StartCoroutine(Flash());

            player.Score++;
            dead = true;

            GetComponentInChildren<BodyAnimator>().enabled = false;

            var force = collision.relativeVelocity * 10;
            body.AddForce(force);

            body.mass = 0.1f;

            StartCoroutine(Destroy());
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
            var renderers = GetComponentsInChildren<Renderer>();

            Material[] originals = new Material[renderers.Length];

            for (int i = 0; i < renderers.Length; i++)
            {
                originals[i] = renderers[i].material;
                renderers[i].material = flash;
            }

            yield return new WaitForSeconds(0.1f);

            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material = originals[i];
            }
        }
    }
}