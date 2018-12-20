using UnityEngine;
using System.Collections;

public class Pox : MonoBehaviour
{
    public GameObject arrow;
    public GameObject readyText;
    public GameObject aimText;
    public GameObject fireText;

    Rigidbody body;
    Player player;
    Box box;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
        box = GetComponent<Box>();

        StartCoroutine(FireArrow());
    }

    void Update()
    {
        if (!box.dead && player != null && !player.invisible && !player.superSpeed)
            body.transform.LookAt(player.transform.position);
    }

    IEnumerator FireArrow()
    {
        yield return new WaitForSeconds(3f);

        if (!box.dead && player != null && !player.invisible && !player.superSpeed)
            readyText.SetActive(true);

        yield return new WaitForSeconds(1f);

        readyText.SetActive(false);

        if (!box.dead && player != null && !player.invisible && !player.superSpeed)
            aimText.SetActive(true);

        yield return new WaitForSeconds(1f);

        aimText.SetActive(false);

        if (!box.dead && player != null && !player.invisible && !player.superSpeed)
        {
            fireText.SetActive(true);

            var newArrow = Instantiate(arrow);
            newArrow.gameObject.SetActive(true);
            newArrow.transform.position = arrow.transform.position;
            newArrow.transform.rotation = arrow.transform.rotation;

            newArrow.GetComponent<Rigidbody>().velocity = arrow.transform.forward.normalized * 20f;
        }

        yield return new WaitForSeconds(0.5f);

        fireText.SetActive(false);

        StartCoroutine(FireArrow());
    }
}