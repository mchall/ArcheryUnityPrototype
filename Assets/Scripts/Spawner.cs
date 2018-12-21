using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject box;
    Player player;

    public float lower;
    public float upper;

    void Start()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(SpawnBox());
    }

    void Update()
    {

    }

    IEnumerator SpawnBox()
    {
        yield return new WaitForSeconds(Random.Range(lower, upper));

        if (player != null)
        {
            var point = Random.onUnitSphere * 3;

            var newBox = Instantiate(box);
            newBox.gameObject.SetActive(true);
            newBox.transform.position = transform.position + point;
            newBox.transform.rotation = transform.rotation;

            StartCoroutine(SpawnBox());
        }
    }
}