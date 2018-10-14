using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Obstacle[] obstacles;
    public float spawnTimerLength;
    float spawnTimer;
    Camera mainCamera;

    void Start()
    {
        spawnTimer = spawnTimerLength;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = spawnTimerLength;
            Vector3 spawnPos = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width + 10f, Random.Range(0, Screen.height)));
            GameObject newObstacle = Instantiate(obstacles[0].gameObject, spawnPos, Quaternion.identity);
        }
    }
}