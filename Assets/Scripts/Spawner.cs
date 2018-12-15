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
        if (player != null)
        {
            var newBox = Instantiate(box);
            newBox.gameObject.SetActive(true);
            newBox.transform.position = transform.position;
            newBox.transform.rotation = transform.rotation;

            yield return new WaitForSeconds(Random.Range(lower, upper));
            StartCoroutine(SpawnBox());
        }
    }
}