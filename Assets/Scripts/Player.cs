using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int Score;
    public bool invisible;

    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        var currentMovement = new Vector3(h, 0, v);
        if (currentMovement.sqrMagnitude > 0.1f)
        {
            currentMovement.Normalize();
            body.MovePosition(body.position + (currentMovement / 8f));
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //todo: controller
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (ground.Raycast(ray, out rayLength))
        {
            Vector3 look = ray.GetPoint(rayLength);

            transform.LookAt(new Vector3(look.x, body.position.y, look.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.position, look), Time.deltaTime * 1f);
        }
    }

    void Update()
    {
        Camera.main.transform.position = new Vector3(body.position.x, Camera.main.transform.position.y, body.position.z - 5);
    }
}