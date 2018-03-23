﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{

    public GameObject ball;
    public GameObject floor;
    public Material[] ballMaterials;

    public float spawnRate = 5.0f;
    public float spawnHeight = 50.0f;

    public Vector3 floorCenter = new Vector3(0, 0, 0);
    public float floorRadius = 50.0f;

    void Start()
    {
        InvokeRepeating("SpawnBall", spawnRate, spawnRate);
    }

    void SpawnBall()
    {

        Material newMat = ballMaterials[Random.Range(0, ballMaterials.Length)];

        Vector3 pos = GetRandomSpawnPosition();
        GameObject newBall = Instantiate(ball, pos, Quaternion.identity);
        newBall.GetComponent<Renderer>().material = newMat;
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 center = new Vector3(floorCenter.x, floorCenter.y + spawnHeight, floorCenter.z);
        Vector3 pos = GameUtils.RandomPointWithinCircle(center, floorRadius);
        return pos;
    }
}