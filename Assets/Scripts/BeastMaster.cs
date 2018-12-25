using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class BeastMaster : MonoBehaviour
{
    public GameObject arrow;
    public Material ghost;
    public SimpleHealthBar healthBar;

    Player player;
    AudioHelper audioHelper;

    float fireTime;
    float powerTime = -9999f;

    void Start()
    {
        player = FindObjectOfType<Player>();
        audioHelper = Camera.main.GetComponent<AudioHelper>();
    }

    void Update()
    {
        var leftTrigger = false;
        var rightTrigger = false;

        if (GamePad.GetState(PlayerIndex.One).IsConnected)
        {
            leftTrigger = GamePad.GetState(PlayerIndex.One).Triggers.Left > 0f;
            rightTrigger = GamePad.GetState(PlayerIndex.One).Triggers.Right > 0f;
        }

        if ((Input.GetButtonDown("Fire1") || leftTrigger) && (Time.time - fireTime >= 0.5f))
        {
            FireProjectile();
            fireTime = Time.time;
        }

        if ((Input.GetButtonDown("Fire2") || rightTrigger) && (Time.time - powerTime >= 30f))
        {
            StartCoroutine(ActivatePower());
            powerTime = Time.time;
        }

        var power = Time.time - powerTime;
        if (power < 0)
            power = 0;
        if (power > 30f)
            power = 30f;
        healthBar.UpdateBar(power, 30f);
    }

    void FireProjectile()
    {
        audioHelper.Bow();

        var newArrow = Instantiate(arrow);
        newArrow.gameObject.SetActive(true);
        newArrow.transform.position = arrow.transform.position;
        newArrow.transform.rotation = arrow.transform.rotation;

        newArrow.GetComponent<Rigidbody>().velocity = arrow.transform.forward.normalized * 20f;
    }

    IEnumerator ActivatePower()
    {
        var renderers = GetComponentsInChildren<Renderer>();

        Material[] originals = new Material[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            originals[i] = renderers[i].material;
            renderers[i].material = ghost;
        }

        player.invisible = true;

        yield return new WaitForSeconds(5f);

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = originals[i];
        }

        player.invisible = false;
    }
}