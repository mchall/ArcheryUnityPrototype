using UnityEngine;

public class ChairAnimator : MonoBehaviour
{
    bool ready;

    void Start()
    {
        ready = true;
    }

    void Update()
    {
        if (ready)
        {
            RotateY(transform, 10f);
        }
    }

    private void RotateY(Transform obj, float speed)
    {
        if (obj != null && obj.transform != null)
        {
            transform.RotateAround(transform.position, Vector3.up, speed);
        }
    }
}