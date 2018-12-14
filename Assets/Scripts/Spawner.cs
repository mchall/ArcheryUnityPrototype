using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject box;

    void Start()
    {
        StartCoroutine(SpawnBox());
    }

    void Update()
    {

    }

    IEnumerator SpawnBox()
    {
        var newBox = Instantiate(box);
        newBox.gameObject.SetActive(true);
        newBox.transform.position = transform.position;
        newBox.transform.rotation = transform.rotation;

        yield return new WaitForSeconds(Random.Range(2.5f, 6f));
        StartCoroutine(SpawnBox());
    }
}