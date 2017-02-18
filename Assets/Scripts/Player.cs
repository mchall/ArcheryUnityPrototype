using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public GameObject arrow;

    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        StartCoroutine(FireProjectile());
    }

    void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        var currentMovement = new Vector3(h, 0, v);
        if (currentMovement.sqrMagnitude > 0.1f)
        {
            currentMovement.Normalize();
            body.MovePosition(body.position + (currentMovement / 15f));
            body.rotation = Quaternion.Lerp(body.rotation, Quaternion.LookRotation(currentMovement), Time.deltaTime * 5f);
        }
    }

    void Update()
    {
        Camera.main.transform.position = new Vector3(body.position.x, Camera.main.transform.position.y, body.position.z - 10);
    }

    IEnumerator FireProjectile()
    {
        var newArrow = Instantiate(arrow);
        newArrow.gameObject.SetActive(true);
        newArrow.transform.position = arrow.transform.position;
        newArrow.transform.rotation = arrow.transform.rotation;

        newArrow.GetComponent<Rigidbody>().velocity = arrow.transform.forward.normalized * 10f;

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FireProjectile());
    }
}