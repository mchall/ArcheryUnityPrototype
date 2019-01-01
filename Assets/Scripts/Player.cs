using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Player : MonoBehaviour
{
    public bool invisible;
    public bool superSpeed;
    public bool invincible;

    public float MovementSpeed = 8f;

    public SimpleTouchController leftController;

    Rigidbody body;
    PersonAnimator animator;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<PersonAnimator>();
    }

    void FixedUpdate()
    {
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY

        var h = leftController.GetTouchPosition.x;
        var v = leftController.GetTouchPosition.y;
        var currentMovement = new Vector3(h, 0, v);
        if (currentMovement.sqrMagnitude > 0.1f)
        {
            currentMovement.Normalize();
            body.MovePosition(body.position + (currentMovement / MovementSpeed));

            if (animator != null)
                animator.enabled = true;
        }
        else
        {
            if (animator != null)
                animator.enabled = false;
        }


        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.position.x < 200 && touch.position.y < 200)
            {
                continue;
            }

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Plane ground = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (ground.Raycast(ray, out rayLength))
            {
                Vector3 look = ray.GetPoint(rayLength);

                transform.LookAt(new Vector3(look.x, body.position.y, look.z));
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.position, look), Time.deltaTime * 1f);
            }
        }

#else
        bool controllerDetected = GamePad.GetState(PlayerIndex.One).IsConnected;

        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        var currentMovement = new Vector3(h, 0, v);
        if (currentMovement.sqrMagnitude > 0.1f)
        {
            currentMovement.Normalize();
            body.MovePosition(body.position + (currentMovement / MovementSpeed));

            if (animator != null)
                animator.enabled = true;
        }
        else
        {
            if (animator != null)
                animator.enabled = false;
        }

        if (!controllerDetected)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane ground = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (ground.Raycast(ray, out rayLength))
            {
                Vector3 look = ray.GetPoint(rayLength);

                transform.LookAt(new Vector3(look.x, body.position.y, look.z));
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.position, look), Time.deltaTime * 1f);
            }
        }
        else if (controllerDetected)
        {
            var h2 = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X;
            var v2 = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y;
            var lookTo = new Vector3(h2, 0, v2);
            if (lookTo.sqrMagnitude > 0.2f)
            {
                lookTo.Normalize();

                var to = body.position + lookTo;
                transform.LookAt(to);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.position, to), Time.deltaTime * 1f);
            }
        }
#endif
    }

    void Update()
    {
        Camera.main.transform.position = new Vector3(body.position.x, Camera.main.transform.position.y, body.position.z - 5);

        if (transform.position.y < -3)
        {
            FindObjectOfType<Canvas>().GetComponent<Scene>().LoseMenu();
        }
    }
}