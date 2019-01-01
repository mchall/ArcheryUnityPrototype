using UnityEngine;
using System.Collections;

public class PowerButton : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void Activate()
    {
        var pewdie1 = FindObjectOfType<Pewdie1>();
        if (pewdie1 != null)
            pewdie1.MobilePower();

        var pewdie2 = FindObjectOfType<Pewdie2>();
        if (pewdie2 != null)
            pewdie2.MobilePower();

        var pewdie3 = FindObjectOfType<BeastMaster>();
        if (pewdie3 != null)
            pewdie3.MobilePower();
    }
}