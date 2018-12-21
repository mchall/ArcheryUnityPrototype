using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{
    public Material flash;
    public int health = 1;
    public float speed = 0.06f;
    public bool trainMode;
    public bool isPox;

    Rigidbody body;
    Player player;
    public bool dead;
    int hitCount;
    float flashTime;
    bool landed;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();

        if (trainMode)
            body.transform.LookAt(player.transform.position);
    }

    void Update()
    {
        if (!dead && player.invisible)
        {
            GetComponentInChildren<BodyAnimator>().enabled = false;
            body.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }

        if (player.superSpeed && !dead)
        {
            body.constraints = RigidbodyConstraints.FreezeAll;
            GetComponentInChildren<BodyAnimator>().enabled = false;
        }
        else if (!dead && !landed)
        {
            body.constraints = RigidbodyConstraints.None;
            GetComponentInChildren<BodyAnimator>().enabled = true;
        }
        else if (!dead && player != null && landed)
        {
            body.constraints = RigidbodyConstraints.None;
            GetComponentInChildren<BodyAnimator>().enabled = true;

            if (!trainMode)
                body.transform.LookAt(player.transform.position);

            if (!isPox)
                body.MovePosition(body.position + (body.transform.forward * speed));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!dead && collision.gameObject.tag == "Height")
        {
            landed = true;
        }

        if (!dead && collision.gameObject.tag == "Death")
        {
            player.Score += health;
            dead = true;
        }

        if (collision.gameObject.tag == "Arrow" || (!isPox && collision.gameObject.tag == "PoxArrow"))
        {
            if (Time.time - flashTime >= 0.15f)
            {
                StartCoroutine(Flash());

                hitCount++;

                if (hitCount >= health)
                {
                    body.constraints = RigidbodyConstraints.None;

                    player.Score += health;
                    dead = true;

                    if (isPox)
                    {
                        GetComponent<Pox>().enabled = false;
                    }

                    GetComponentInChildren<BodyAnimator>().enabled = false;

                    body.mass = 1f;

                    var force = collision.relativeVelocity * 10;
                    body.AddForce(force);

                    body.mass = 0.1f;

                    StartCoroutine(Destroy());
                }

                flashTime = Time.time;
            }
        }
        else if (collision.gameObject.tag == "Trolley")
        {
            var force = collision.relativeVelocity.normalized * 15;
            body.AddForce(new Vector3(force.x, 5, force.z), ForceMode.Impulse);
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