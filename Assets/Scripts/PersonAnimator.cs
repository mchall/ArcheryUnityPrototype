using UnityEngine;

public class PersonAnimator : MonoBehaviour
{
    bool ready;
    Transform leg1, leg2;
    bool leg1dir = true;
    bool leg2dir = false;

    float legspeed = 50f;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).gameObject;
            if (child.name == "Leg1")
                leg1 = child.transform.GetChild(0);
            else if (child.name == "Leg2")
                leg2 = child.transform.GetChild(0);
        }
        ready = true;
    }

    void Update()
    {
        if (ready)
        {
            MoveZ(leg1, -5, 5, legspeed, ref leg1dir);
            MoveZ(leg2, -5, 5, legspeed, ref leg2dir);
        }
    }

    private void MoveZ(Transform obj, float min, float max, float speed, ref bool dir)
    {
        if (obj != null && obj.transform != null)
        {
            var z = obj.localPosition.z;
            if (z >= max)
                dir = true;
            else if (z <= min)
                dir = false;

            var dest = new Vector3(obj.localPosition.x, obj.localPosition.y, dir ? min : max);
            obj.localPosition = Vector3.MoveTowards(obj.localPosition, dest, Time.deltaTime * speed);
        }
    }
}