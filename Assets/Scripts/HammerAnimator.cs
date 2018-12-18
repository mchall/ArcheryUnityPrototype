using UnityEngine;

public class HammerAnimator : MonoBehaviour
{
    bool ready;
    bool hammerDir = true;
    float hammerSpeed = 50f;

    void Start()
    {
        ready = true;
    }

    void Update()
    {
        if (ready)
        {
            MoveY(transform, -0.7f, 0.7f, 10f, ref hammerDir);
        }
    }

    private void MoveY(Transform obj, float min, float max, float speed, ref bool dir)
    {
        if (obj != null && obj.transform != null)
        {
            var x = obj.localRotation.y;
            if (x >= max)
                dir = true;
            else if (x <= min)
                dir = false;

            transform.RotateAround(transform.position, Vector3.up * (dir ? 1 : -1), speed);
        }
    }
}