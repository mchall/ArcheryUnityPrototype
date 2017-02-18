using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{
    Rigidbody body;
    Player player;
    bool dead;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        player = FindObjectsOfType<Player>()[0];
    }

    void Update()
    {
        if (player != null && !dead)
        {
            body.transform.LookAt(player.transform.position);
            body.MovePosition(body.position + (body.transform.forward * 0.01f));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            dead = true;
        }
        else if (!dead && collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}