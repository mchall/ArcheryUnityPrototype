﻿using System.Collections;
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
        StartCoroutine(SpawnBox());
    }

    void Update()
    {
        if (player == null)
            player = FindObjectOfType<Player>();
    }

    IEnumerator SpawnBox()
    {
        yield return new WaitForSeconds(Random.Range(lower, upper));

        if (player != null && !player.superSpeed && !player.invisible)
        {
            var point = Random.onUnitSphere * 3;

            var newBox = Instantiate(box);
            newBox.gameObject.SetActive(true);
            newBox.transform.position = transform.position + point;
            newBox.transform.rotation = transform.rotation;
        }

        StartCoroutine(SpawnBox());
    }
}