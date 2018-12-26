using UnityEngine;

public class TrolleyAnimator : MonoBehaviour
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
            RotateY(transform, 15f);
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